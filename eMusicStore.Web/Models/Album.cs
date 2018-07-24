using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMusicStore.Web.Models
{
    /// <summary>
    /// 专辑
    /// </summary>
    public class Album
    {
        /// <summary>
        /// 专辑ID
        /// </summary>
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }
        /// <summary>
        /// 流派ID
        /// </summary>
        [DisplayName("流派")]
        [Required(ErrorMessage = "流派是必填项")]
        public int GenreId { get; set; }
        /// <summary>
        /// 艺术家ID
        /// </summary>
        [DisplayName("艺术家")]
        [Required(ErrorMessage = "艺术家是必填项")]
        public int ArtistId { get; set; }
        /// <summary>
        /// 专辑标题
        /// </summary>
        [DisplayName("专辑标题")]
        [Required(ErrorMessage = "专辑标题是必填项")]
        [StringLength(160, ErrorMessage = "专辑标题字符长度不能超过{1}")]
        public string Title { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [DisplayName("单价")]
        [Required(ErrorMessage = "单价是必填项")]
        [Range(1.0, 100.0, ErrorMessage = "单价只能介于{1}~{2}")]
        public decimal Price { get; set; }
        /// <summary>
        /// 专辑URL
        /// </summary>
        [DisplayName("专辑URL")]
        [StringLength(1024, ErrorMessage = "专辑URL字符长度不能超过{1}")]
        public string AlbumArtUrl { get; set; }
        /// <summary>
        /// 所属流派
        /// </summary>
        [DisplayName("所属流派")]
        public virtual Genre Genre { get; set; }
        /// <summary>
        /// 所属艺术家
        /// </summary>
        [DisplayName("所属艺术家")]
        public virtual Artist Artist { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}