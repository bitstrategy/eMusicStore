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
    /// 艺术家
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// 艺术家ID
        /// </summary>
        [ScaffoldColumn(false)]
        public int ArtistId { get; set; }
        /// <summary>
        /// 艺术家
        /// </summary>
        [DisplayName("艺术家")]
        [Required(ErrorMessage = "艺术家是必填项")]
        [StringLength(100, ErrorMessage = "艺术家字符长度不能超过{1}")]
        public string Name { get; set; }
    }
}