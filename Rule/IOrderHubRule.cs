using HIS.Entity;
using HIS.ReqDTO;

namespace HIS.Rule
{
    public interface IOrderHubRule
    {
        /// <summary>
        /// 建卡验证
        /// </summary>
        /// <param name="cardNo">证件号</param>
        /// <param name="cardType">证件类型</param>
        /// <returns></returns>
        public RuleFlag CheckCard(string cardNo,int cardType);


        /// <summary>
        /// 新增订单 是否已存在订单，是否可以预约
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public RuleFlag AddOrder(ReqAddOrderDTO order);


        /// <summary>
        /// 取消订单 是否可以取消
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public RuleFlag CancelOrder(EntOrder order);


    }
}
