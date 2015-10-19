using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerExam.Model
{
    /// <summary>
    /// 试题信息
    /// </summary>
    public class M_Topic
    {
        public string BasicTypeId { get; set; }
        public string JudgeEngineId { get; set; }
        public string TopicTypeId { get; set; }
        public string TopicTypeName { get; set; }
        public string TopicId { get; set; }
        public string SubTopicId { get; set; }
        public int DisplayId { get; set; }
        public string TopicNo { get; set; }
        public int DisplayMode { get; set; }
        public string TopicFace { get; set; }
        public int OptionNumber { get; set; }
        public string AppPath { get; set; }
        public string SampleDoc { get; set; }
        public bool Difficult { get; set; }
        public string EditorType { get; set; }
        public string EditorProp { get; set; }
        public string StandardAnswer { get; set; }
        public bool HaveUserAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool Changed { get; set; }
        public bool IsShow { get; set; }
        public string ErrorHint { get; set; }
        public string JudgeLevel { get; set; }
        public double Mark { get; set; }
        public double Score { get; set; }
        public string ShowResFileName { get; set; }
        public string T3Type { get; set; }
        public string CallT3Para { get; set; }
    }
}
