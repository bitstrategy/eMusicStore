using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eMusicStore.Web.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [DisplayName("订单号")]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [DisplayName("账号")]
        [ScaffoldColumn(false)]
        public string Username { get; set; }

        /// <summary>
        /// 客户名
        /// </summary>
        [DisplayName("客户名")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(100, ErrorMessage = "{0}字符长度不能超过{1}")]
        public string FirstName { get; set; }

        /// <summary>
        /// 客户姓
        /// </summary>
        [DisplayName("客户姓")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(100, ErrorMessage = "{0}字符长度不能超过{1}")]
        public string LastName { get; set; }
        /// <summary>
        /// 邮寄地址
        /// </summary>
        [DisplayName("邮寄地址")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(100, ErrorMessage = "{0}字符长度不能超过{1}")]
        public string Address { get; set; }
        /// <summary>
        /// 邮寄省份
        /// </summary>
        [DisplayName("邮寄省份")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(50, ErrorMessage = "{0}字符长度不能超过{1}")]
        public string City { get; set; }

        /// <summary>
        /// 邮寄城市
        /// </summary>
        [DisplayName("邮寄城市")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(50, ErrorMessage = "{0}字符长度不能超过{1}")]
        public string State { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [DisplayName("邮编")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(10, ErrorMessage = "{0}字符长度不能超过{1}")]
        public string PostalCode { get; set; }

        /// <summary>
        /// 邮寄国家
        /// </summary>
        [DisplayName("邮寄国家")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(40, ErrorMessage = "{0}字符长度不能超过{1}")]
        public string Country { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName("联系电话")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(11, ErrorMessage = "{0}字符长度不能超过{1}")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DisplayName("邮箱")]
        [Required(ErrorMessage = "{0}是必填项")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "{0}格式不正确")]
        [StringLength(50, ErrorMessage = "{0}字符长度不能超过{1}")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "{0}格式不正确")]
        public string Email { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        [DisplayName("总金额")]
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        [DisplayName("订单日期")]
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }
    }
}