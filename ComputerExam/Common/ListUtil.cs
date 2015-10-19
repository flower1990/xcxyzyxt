using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerExam
{
    public class JobState
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class JobScoreState
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ListUtil
    {
        public List<JobState> GetJobState()
        {
            List<JobState> listJobState = new List<JobState>();

            JobState jobState1 = new JobState() { Id = -1, Name = "所有作业数据" };
            JobState jobState2 = new JobState() { Id = 0, Name = "未完成的作业" };
            JobState jobState3 = new JobState() { Id = 1, Name = "已完成的作业" };

            listJobState.Add(jobState1);
            listJobState.Add(jobState2);
            listJobState.Add(jobState3);

            return listJobState;
        }

        public List<JobScoreState> GetJobScoreState()
        {
            List<JobScoreState> listJobScoreState = new List<JobScoreState>();

            JobScoreState jobScoreState1 = new JobScoreState() { Id = 1, Name = "当前作业成绩" };
            JobScoreState jobScoreState2 = new JobScoreState() { Id = 2, Name = "历史作业成绩" };

            listJobScoreState.Add(jobScoreState1);
            listJobScoreState.Add(jobScoreState2);

            return listJobScoreState;
        }
    }
}
