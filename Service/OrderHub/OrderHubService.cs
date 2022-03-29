using HIS.Context;
using HIS.Entity;
using HIS.ReqDTO;
using HIS.Rule;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HIS.Service.OrderHub
{
    public class OrderHubService:IOrderHubService
    {
        private readonly IOrderHubRule rule;

        public OrderHubService(IOrderHubRule _rule)
        {
            rule = _rule;
        }


        /// <summary>
        /// 科室信息
        /// </summary>
        /// <returns></returns>
        public Response GetDept()
        {
            try
            {
                using (var db = new DataContext())
                {
                    var dbr = db.Dept2.ToList();
                    return new Response() { Code = "1", Message = "查询成功", Result = dbr };
                }
            }catch (Exception ex)
            {
                return new Response() { Code = "3", Message = ex.Message, Result = "" };
            }
        }


        /// <summary>
        /// 医生信息
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public Response GetDoctor(ReqDoctorDTO dto)
        {
            try
            {
                if (dto == null || string.IsNullOrEmpty(dto.DeptId))
                {
                    return new Response() { Code = "2", Message = "传参错误", Result = "" };
                }
                using (var db = new DataContext())
                {
                    var doctor = db.Doctor.Where
                        (x => x.Status == 1 && db.DepDoc
                        .Where(y => y.DeptId == dto.DeptId)
                        .Select(z => z.DoctorId)
                        .Contains(x.DoctorId))
                        .Select(t => new { t.DoctorId, t.DoctorName, t.DoctorLevel, t.Sex, t.Desc })
                        .ToList();
                    return new Response() { Code = "1", Message = "查询成功", Result = doctor };
                }
            }catch (Exception ex)
            {
                return new Response() { Code = "3", Message = ex.Message, Result = "" };
            }
        }


        /// <summary>
        /// 排班信息
        /// </summary>
        /// <param name="dto">排班object</param>
        /// <returns></returns>
        public Response GetSchedule(ReqScheduleDTO dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.DeptId))
                {
                    return new Response() { Code = "2", Message = "科室ID必传", Result = "" };
                }
                else if (dto.StartDate > dto.EndDate)
                {
                    return new Response() { Code = "2", Message = "结束日期不能小于开始日期", Result = "" };
                }
                else if (dto.StartDate < DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    return new Response() { Code = "2", Message = "开始日期不能小于系统日期", Result = "" };
                }
                using (var db = new DataContext())
                {
                    if (string.IsNullOrEmpty(dto.DoctorId))
                    {
                        var dbr = db.Schedules
                            .Join(db.Dept2, a => a.DeptId, b => b.DeptId, (a, b) => new { f1 = a, f2 = b })
                            .Join(db.Doctor, a => a.f1.DoctorId, b => b.DoctorId, (a, b) => new { a.f1.ScheduleId, a.f1.ScheduleDate, a.f1.DeptId, a.f2.DeptName, a.f1.DoctorId, b.DoctorName, a.f1.Amt, a.f1.TotalNum, a.f1.UsedNum, a.f1.Status, a.f1.TimeType, a.f1.BeginTime, a.f1.EndTime })
                            .Where(x => x.DeptId.Equals(dto.DeptId) && x.ScheduleDate >= dto.StartDate && x.ScheduleDate <= dto.EndDate)
                            .Select(x => new { x.ScheduleId, ScheduleDate = x.ScheduleDate.ToString(), x.DeptId, x.DeptName, x.DoctorId, x.DoctorName, x.Amt, x.TotalNum, x.UsedNum, x.Status, x.TimeType, x.BeginTime, x.EndTime })
                            .ToList();
                        return new Response() { Code = "1", Message = "成功", Result = dbr };
                    }
                    else
                    {
                        var dbr = db.Schedules
                            .Join(db.Dept2, a => a.DeptId, b => b.DeptId, (a, b) => new { f1 = a, f2 = b })
                            .Join(db.Doctor, a => a.f1.DoctorId, b => b.DoctorId, (a, b) => new { a.f1.ScheduleId, a.f1.ScheduleDate, a.f1.DeptId, a.f2.DeptName, a.f1.DoctorId, b.DoctorName, a.f1.Amt, a.f1.TotalNum, a.f1.UsedNum, a.f1.Status, a.f1.TimeType, a.f1.BeginTime, a.f1.EndTime })
                            .Where(x => x.DeptId.Equals(dto.DeptId) && x.ScheduleDate >= dto.StartDate && x.ScheduleDate <= dto.EndDate && x.DoctorId.Equals(dto.DoctorId))
                            .Select(x => new { x.ScheduleId, ScheduleDate = x.ScheduleDate.ToString(), x.DeptId, x.DeptName, x.DoctorId, x.DoctorName, x.Amt, x.TotalNum, x.UsedNum, x.Status, x.TimeType, x.BeginTime, x.EndTime })
                            .ToList();
                        return new Response() { Code = "1", Message = "成功", Result = dbr };
                    }
                }
            }catch (Exception ex)
            {
                return new Response() { Code = "3", Message = ex.Message, Result = "" };
            }
        }


        /// <summary>
        /// 号源信息
        /// </summary>
        /// <returns></returns>
        public Response GetSource(ReqSourceDTO dto)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var dbr = db.Sources.Where(x => x.ScheduleId.Equals(dto.ScheduleId)).ToList();
                    return new Response() { Code = "1", Message = "查询成功", Result = dbr };
                }
            }catch (Exception ex)
            {
                return new Response() { Code = "3", Message = ex.Message, Result = "" };
            }
        }


        /// <summary>
        /// 查卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Response GetCard(ReqQueryCardDTO dto)
        {
            try
            {
                //规则系统，卡号是否符合规则
                var reRule = rule.CheckCard(dto.CardNo, dto.CardType);
                if (!reRule.Flag)
                {
                    return new Response() { Code = "2", Message = reRule.Message, Result = "" };
                }
                using (var db = new DataContext())
                {
                    var dbr = db.Card.Where(x => x.CardNo.Equals(dto.CardNo) && x.Name.Equals(dto.Name)).Select(y => y.PatientId).ToList();
                    if (dbr.Count > 0)
                    {
                        return new Response() { Code = "1", Message = "存在信息", Result = new { CardNo = dbr[0] } };
                    }
                    else
                    {
                        return new Response() { Code = "2", Message = "不存在信息", Result = "" };
                    }
                }
            }catch (Exception ex)
            {
                return new Response() { Code = "3", Message = ex.Message, Result = "" };
            }
        }


        /// <summary>
        /// 建卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Response> RegCard(ReqRegCardDTO dto)
        {
            try
            {
                //规则系统，卡号是否符合规则
                var reRule = rule.CheckCard(dto.CardNo, dto.CardType);
                if (!reRule.Flag)
                {
                    return new Response() { Code = "2", Message = reRule.Message, Result = "" };
                }
                using (var db = new DataContext())
                {
                    //检查是否已建档
                    var d = db.Card.Where(x => x.CardNo.Equals(dto.CardNo) && x.CardType.Equals(dto.CardType)).Select(y => y.PatientId).ToList();
                    if (d.Count == 0)
                    {
                        //字典表读取当前卡号
                        var dict = db.Dictionaries.Where(x => x.Tables.Equals("Card") && x.Code.Equals("CurrentCardNo")).ToList();
                        if (dict.Count == 1)
                        {
                            var ccn = Convert.ToInt32(dict[0].Value);
                            var card = new EntCard();
                            card.Name = dto.Name;
                            card.CardNo = dto.CardNo;
                            card.CardType = dto.CardType;
                            card.Birth = dto.Birth;
                            card.Sex = dto.Sex;
                            card.Phone = dto.Phone;
                            card.Address = dto.Address;
                            card.PatientId = ccn;
                            card.ChannelId = dto.ChannelId;
                            db.Card.Add(card);
                            //更新字典表
                            dict[0].Value = (ccn + 1).ToString();
                            db.Dictionaries.Update(dict[0]);
                            await db.SaveChangesAsync();
                            return new Response() { Code = "1", Message = "建卡成功", Result = new { PatientId = ccn } };
                        }
                        else
                        {
                            return new Response() { Code = "2", Message = "建卡异常 检查字段Card.CurrentCardNo", Result = "" };
                        }
                    }
                    else
                    {
                        return new Response() { Code = "2", Message = "已有卡", Result = "" };
                    }
                }
            }catch (Exception ex)
            {
                return new Response() { Code = "3", Message = ex.Message, Result = "" };
            }
        }


        /// <summary>
        /// 新增订单
        /// </summary>
        /// <returns></returns>
        public async Task<Response> AddOrder(ReqAddOrderDTO dto)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var reRule = rule.AddOrder(dto);
                    if (!reRule.Flag)
                    {
                        return new Response() { Code = "2", Message = reRule.Message, Result = "" };
                    }
                    var p = db.Dictionaries.Where(x => x.Tables.Equals("Order") && x.Code.Equals("OrderNo")).ToList();
                    if (p.Count > 0)
                    {
                        EntOrder order = new EntOrder();
                        order.CardNo = dto.CardNo;
                        order.OrderDate = DateTime.Now;
                        order.Status = 1;
                        order.OrderId = Convert.ToInt32(p[0].Value) + 1;
                        order.ScheduleId = dto.ScheduleId;
                        order.ScheduleDate = dto.ScheduleDate;
                        order.SourceId = dto.SourceId;
                        order.BeginTime = dto.BeginTime;
                        order.EndTime = dto.EndTime;
                        order.DeptId = dto.DeptId;
                        order.DoctorId = dto.DoctorId;
                        order.ChannelId = dto.ChannelId;
                        order.Phone = dto.Phone;
                        db.Order.Add(order);
                        //更新OrderNo
                        p[0].Value = (order.OrderId).ToString();
                        db.Dictionaries.Update(p[0]);
                        int result = await db.SaveChangesAsync();
                        if(result > 0)
                        {
                            //更新Schedule Source
                            db.Database.ExecuteSqlRaw($"update schedule set usednum=usednum+1 where scheduleid='{dto.ScheduleId}'");
                            db.Database.ExecuteSqlRaw($"update source set usednum=usednum+1 where sourceid='{dto.SourceId}' and begintime='{dto.BeginTime}'");
                            return new Response() { Code = "1", Message = "提交成功", Result = new { OrderId = order.OrderId } };
                        }
                        else
                        {
                            order.Status = 99;
                            db.Update(order);
                            db.SaveChanges();
                            return new Response() { Code = "2", Message = "提交失败", Result = "" };
                        }
                    }
                    else
                    {
                        return new Response() { Code = "2", Message = "失败，未找到Order.OrderNo", Result = "" };
                    }
                }catch (Exception ex)
                {
                    return new Response() { Code = "3", Message = ex.Message, Result = "" };
                }
            }
        }


        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Response> CancelOrder(ReqCancelOrderDTO dto)
        {
            try
            {
                using (var db = new DataContext())
                {
                    //通过订单号、渠道ID、手机号，查找是否存在该订单
                    var order = db.Order.SingleOrDefault(x => x.OrderId.Equals(dto.OrderId) && x.ChannelId.Equals(dto.ChannelId) && x.Phone.Equals(dto.Phone));
                    if (order != null)
                    {
                        var reRule = rule.CancelOrder(order);
                        if (!reRule.Flag)
                        {
                            return new Response() { Code = "2", Message = reRule.Message, Result = "" };
                        }
                        order.Status = 2;
                        db.Order.Update(order);
                        int result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return new Response() { Code = "1", Message = "取消成功", Result = "" };
                        }
                        else
                        {
                            return new Response() { Code = "2", Message = "取消失败，未知原因", Result = "" };
                        }
                    }
                    else
                    {
                        return new Response() { Code = "2", Message = "未找到或信息不一致", Result = "" };
                    }
                }
            }catch(Exception ex)
            {
                return new Response() { Code = "3", Message = ex.Message, Result = "" };
            }
            
        }
    }
}
