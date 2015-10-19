using ComputerExam.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComputerExam.Model;

namespace ComputerExam.ExamPaper
{
    public partial class frmFenLuBianJi : Form
    {
        int flag = 0;  //1增加 2编辑
        M_Accounting accounting = new M_Accounting();
        List<M_Accounting> accountingList = new List<M_Accounting>();
        List<M_AccountingSubjectType> listSubjectType = new List<M_AccountingSubjectType>();
        List<M_AccountingSubject> listSubject = new List<M_AccountingSubject>();

        private bool ValidateEmpty()
        {
            if (cboDirection.Text == "---请选择---")
            {
                PublicClass.ShowMessageOk("请将当前分录的方向、会计科目与金额填写完整后再行增加！");
                cboDirection.Focus();
                return false;
            }

            if (cboType.Text == "---请选择---")
            {
                PublicClass.ShowMessageOk("请将当前分录的方向、会计科目与金额填写完整后再行增加！");
                cboType.Focus();
                return false;
            }

            if (cboSubject.Text == "---请选择---")
            {
                PublicClass.ShowMessageOk("请将当前分录的方向、会计科目与金额填写完整后再行增加！");
                cboSubject.Focus();
                return false;
            }

            if (txtAmount.Text.Trim() == string.Empty)
            {
                PublicClass.ShowMessageOk("请将当前分录的方向、会计科目与金额填写完整后再行增加！");
                txtAmount.Focus();
                return false;
            }

            return true;
        }

        private M_Accounting InitialEntity()
        {
            M_Accounting entity = new M_Accounting();

            switch (flag)
            {
                case 1:
                    entity.Id = Guid.NewGuid().ToString();
                    entity.Direction = cboDirection.Text;
                    entity.Type = cboType.Text;
                    entity.Subject = cboSubject.Text;
                    entity.Amount = txtAmount.Text.Trim();
                    entity.Content = string.Format("{0}： {1} {2}", entity.Direction, entity.Subject, entity.Amount);
                    break;
                case 2:
                    entity.Id = accounting.Id;
                    entity.Direction = cboDirection.Text;
                    entity.Type = cboType.Text;
                    entity.Subject = cboSubject.Text;
                    entity.Amount = txtAmount.Text.Trim();
                    entity.Content = string.Format("{0}： {1} {2}", entity.Direction, entity.Subject, entity.Amount);
                    break;
                default:
                    break;
            }

            return entity;
        }

        private void InitialList()
        {
            listResult.DataSource = null;

            listResult.DataSource = accountingList;
            listResult.ValueMember = "Subject";
            listResult.DisplayMember = "Content";
        }

        private void ClearRecord()
        {
            cboDirection.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            cboSubject.SelectedIndex = 0;
            txtAmount.Text = string.Empty;
        }

        public frmFenLuBianJi()
        {
            InitializeComponent();
        }

        private void frmFenLuBianJi_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> subject = new List<string>();
                List<string> subjectName = new List<string>();
                List<string> typeName = new List<string>() { "资产类", "负债类", "所有者权益类", "成本类", "损益类" };

                for (int i = 0; i < 5; i++)
                {
                    M_AccountingSubjectType entity = new M_AccountingSubjectType();
                    entity.Id = (i + 1).ToString();
                    entity.SubjectType = typeName[i];
                    listSubjectType.Add(entity);
                }

                string listKeMu = PublicClass.SowerExamPlugn.GetKuaiJiKeMuList(PublicClass.StudentDir);
                subject = listKeMu.Split('♂').ToList();
                for (int i = 0; i < subject.Count; i++)
                {
                    subjectName = subject[i].Split('※').ToList();
                    for (int j = 0; j < subjectName.Count; j++)
                    {
                        M_AccountingSubject entity = new M_AccountingSubject();
                        entity.Id = (j + 1).ToString();
                        entity.ParentId = (i + 1).ToString();
                        entity.SubjectName = subjectName[j];
                        listSubject.Add(entity);
                    }
                }

                listSubjectType.Insert(0, new M_AccountingSubjectType { Id = "0", SubjectType = "---请选择---" });
                cboType.DataSource = listSubjectType;
                cboType.ValueMember = "Id";
                cboType.DisplayMember = "SubjectType";
                cboType.SelectedValueChanged += cboType_SelectedValueChanged;

                accountingList = CommonUtil.listAccounting;
                cboDirection.SelectedIndex = 0;
                InitialList();

                btnSave.Visible = false;
            }
            catch (Exception ex)
            {
                PublicClass.ShowMessageOk(ex.Message);
                throw;
            }
        }

        void cboType_SelectedValueChanged(object sender, EventArgs e)
        {
            string typeId = cboType.SelectedValue.ToString();

            List<M_AccountingSubject> subjectName = listSubject.FindAll(s => s.ParentId == typeId).ToList();
            subjectName.Insert(0, new M_AccountingSubject { ParentId = "0", SubjectName = "---请选择---" });
            cboSubject.DataSource = subjectName;
            cboSubject.ValueMember = "ParentId";
            cboSubject.DisplayMember = "SubjectName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateEmpty()) return;

            flag = 1;
            accountingList.Add(InitialEntity());

            ClearRecord();
            InitialList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listResult.SelectedItems.Count == 0) return;

            string subject = listResult.SelectedValue.ToString();
            accounting = accountingList.Find(a => a.Subject == subject);

            string message = string.Format("确定删除分录项“{0}”吗？", accounting.Content);
            DialogResult dialogResult = PublicClass.ShowMessageOKCancel(message);

            if (dialogResult == DialogResult.OK)
            {
                accountingList.Remove(accounting);
                InitialList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listResult.SelectedItems.Count == 0) return;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnSaveEdit.Enabled = false;

            flag = 2;
            string subject = listResult.SelectedValue.ToString();
            accounting = accountingList.Find(a => a.Subject == subject);
            string parentId = listSubject.Find(s => s.SubjectName == subject).ParentId;
            accounting.Type = listSubjectType.Find(s => s.Id == parentId).SubjectType;

            cboDirection.Text = accounting.Direction;
            cboType.Text = accounting.Type;
            cboSubject.Text = accounting.Subject;
            txtAmount.Text = accounting.Amount;

            btnEdit.Visible = false;
            btnSave.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateEmpty()) return;

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnSaveEdit.Enabled = true;

            M_Accounting accountingSave = InitialEntity();
            for (int i = 0; i < accountingList.Count; i++)
            {
                if (accountingList[i].Id == accountingSave.Id)
                {
                    accountingList[i] = accountingSave;
                }
            }

            ClearRecord();
            InitialList();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (listResult.Items.Count == 0)
            {
                PublicClass.ShowMessageOk("目前没有添加任何分录数据，请将分录填写完整后再进行保存。");
                return;
            }

            if (listResult.Items.Count == 1)
            {
                PublicClass.ShowMessageOk("当前分录不完整，请将分录填写完整后再进行保存。");
                return;
            }

            CommonUtil.listAccounting = accountingList;

            DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
