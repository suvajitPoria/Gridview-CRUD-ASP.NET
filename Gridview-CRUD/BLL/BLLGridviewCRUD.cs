using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Model;
using DAL;
namespace BLL
{
    public class BLLGridviewCRUD
    {
        public object ReadStudent()
        {
            DALGirdviewCRUD dal = new DALGirdviewCRUD();
            DataTable dt = dal.ReadStudent();
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return "No Record is found";
            }
        }


        public string CreateStudent(StudentInfo studentInfo,out bool status)
        {
            DALGirdviewCRUD dal = new DALGirdviewCRUD();
            return dal.CreateStudent(studentInfo,out status);
        }

        public string UpdateStudent(StudentInfo studentInfo,int StudentId, out bool status)
        {
            DALGirdviewCRUD dal = new DALGirdviewCRUD();
            return dal.UpdateStudent(studentInfo,StudentId, out status);
        }

        public string DeleteStudent(int StudentId, out bool status)
        {
            DALGirdviewCRUD dal = new DALGirdviewCRUD();
            return dal.DeleteStudent(StudentId, out status);
        }
    }
}
