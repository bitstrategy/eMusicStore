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
    /// 流派
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// 流派ID
        /// </summary>
        [ScaffoldColumn(false)]
        public int GenreId { get; set; }
        /// <summary>
        /// 流派
        /// </summary>
        [DisplayName("流派")]
        [Required(ErrorMessage = "流派是必填项")]
        [StringLength(100, ErrorMessage = "流派字符长度不能超过{1}")]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        [StringLength(1024, ErrorMessage = "描述字符长度不能超过{1}")]
        public string Description { get; set; }

        /// <summary>
        /// 下属专辑列表
        /// </summary>
        public List<Album> Albums { get; set; }
    }
}