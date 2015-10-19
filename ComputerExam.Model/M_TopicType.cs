using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    /// <summary>
    /// 题型
    /// </summary>
    public class M_TopicType
    {
        /// <summary>
        /// 题型ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 题型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 基础题型ID
        /// </summary>
        public string BasicTypeId { get; set; }
        /// <summary>
        /// 评判引擎
        /// </summary>
        public string JudgeEngineId { get; set; }

        public bool AllowSubTopic { get; set; }
        /// <summary>
        /// 试题编号
        /// </summary>
        public int TopicNumber { get; set; }
        /// <summary>
        /// 打分
        /// </summary>
        public double Mark { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// 试题
        /// </summary>
        public List<M_Topic> Topics { get; set; }
    }
}
