using HIS.Entity;
using HIS.ReqDTO;

namespace HIS.Rule
{
    public class OrderHubRule : IOrderHubRule
    {

        /// <summary>
        /// 验证证件规则
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public RuleFlag CheckCard(string cardNo, int cardType)
        {
            //符合条件返回TRUE，不符合条件返回FALSE
            // CardType:1-身份证
            //仅实现身份证
            if (cardType == 1 && cardNo.Length == 18)
            {
                return CheckIDCard18(cardNo);//验证18位身份证
            }else if(cardType == 1 && cardNo.Length == 15)
            {
                return CheckIdCard15(cardNo);//验证15位身份证
            }
            else
            {
                return new RuleFlag(false,"未通过证件验证规则");
            }
        }


        /// <summary>
        /// 新增订单 是否已存在订单，是否可以预约
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public RuleFlag AddOrder(ReqAddOrderDTO order)
        {
            if(int.TryParse(order.CardNo, out int id))
            {
                using (var db = new DataContext())
                {
                    var yysd = DateTime.Parse(order.ScheduleDate.ToShortDateString() + " " + order.BeginTime);//预约开始时间
                    if (yysd > DateTime.Now)
                    {
                        var card = db.Card.SingleOrDefault(x => x.PatientId == id).PatientId;//是否存在档案
                        if (card > 0)
                        {
                            var sch = db.Schedules.SingleOrDefault(x => x.ScheduleId.Equals(order.ScheduleId) && x.ScheduleDate.Equals(order.ScheduleDate) && x.DeptId.Equals(order.DeptId) && x.DoctorId.Equals(order.DoctorId));//判断排班是否有效
                            if (sch != null)
                            {
                                if(sch.Status == 1)
                                {
                                    if (sch.TotalNum == sch.UsedNum)
                                    {
                                        return new RuleFlag(false, "该排班已约满");
                                    }
                                    else
                                    {
                                        var source = db.Sources.SingleOrDefault(x => x.SourceId.Equals(order.SourceId) && x.BeginTime.Equals(order.BeginTime) && x.EndTime.Equals(order.EndTime) && x.ScheduleId.Equals(order.ScheduleId));//判断号源是否有效
                                        if (source != null)
                                        {
                                            if(source.Status == 1)
                                            {
                                                if (source.TotalNum == source.UsedNum)
                                                {
                                                    return new RuleFlag(false, "该时段已约满");
                                                }
                                                else
                                                {
                                                    var newOrder = db.Order.Where(x => x.CardNo.Equals(order.CardNo) && x.ScheduleDate.Equals(order.ScheduleDate) && x.DeptId.Equals(order.DeptId)).Select(y => y.OrderId).ToList();
                                                    if (newOrder != null && newOrder.Count > 0)
                                                    {
                                                        return new RuleFlag(false, "已有订单" + newOrder[0]);
                                                    }
                                                    else
                                                    {
                                                        return new RuleFlag(true, "可以预约");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                return new RuleFlag(false, "号源不可约");
                                            }
                                        }
                                        else
                                        {
                                            return new RuleFlag(false, "号源不存在或错误");
                                        }
                                    }
                                    
                                }
                                else if(sch.Status == 2)
                                {
                                    return new RuleFlag(false, "排班已停诊");
                                }
                                else
                                {
                                    return new RuleFlag(false, "排班状态异常");
                                }
                            }
                            else
                            {
                                return new RuleFlag(false, "排班不存在或非唯一");
                            }

                        }
                        else
                        {
                            return new RuleFlag(false, "未找到该卡号");
                        }
                    }
                    else
                    {
                        return new RuleFlag(false, "预约时间不能小于当前时间");
                    }
                    
                }
            }
            else
            {
                return new RuleFlag(false, "卡号错误，非法字符");
            }
        }


        /// <summary>
        /// 取消订单 是否可以取消
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public RuleFlag CancelOrder(EntOrder order)
        {
            try
            {
                var yysd = DateTime.Parse(order.ScheduleDate.ToShortDateString() + " " + order.BeginTime);
                if (yysd > DateTime.Now)
                {
                    if(order.Status == 1)
                    {
                        return new RuleFlag(true, "允许取消");
                    }
                    else
                    {
                        return new RuleFlag(false, "订单已取消，取消失败");
                    }
                }
                else
                {
                    return new RuleFlag(false, "已过取消时间");
                }
            }catch (Exception ex)
            {
                return new RuleFlag(false, ex.Message);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 验证18位证件号
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private RuleFlag CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return new RuleFlag(false,"数字验证失败");//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return new RuleFlag(false, "省份错误");//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false||time>DateTime.Now||DateTime.Now.Year-time.Year>150)
            {
                return new RuleFlag(false, "出生日期错误");//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,ralph lauren home store,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return new RuleFlag(false,"证件号有误");//校验码验证
            }
            return new RuleFlag(true, "验证通过");//契合GB11643-1999标准
        }


        /// <summary>
        /// 验证15位证件号
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private RuleFlag CheckIdCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return new RuleFlag(false, "数字验证错误");//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return new RuleFlag(false, "省份错误");//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return new RuleFlag(false, "生日验证失败");//诞辰验证
            }
            return new RuleFlag(true, "验证通过");//合乎15位身份证标准
        }

        
    }
}
