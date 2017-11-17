using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_BD
{
    class Student
    {
        public DataTable student = new DataTable("Student");
        public DataColumn student_id = new DataColumn("Student_id", typeof(int));
        public DataColumn student_name = new DataColumn("Student_name", typeof(string));
        public DataColumn student_surname = new DataColumn("Student_surname", typeof(string));
        public DataColumn group_id = new DataColumn("Group_id", typeof(int));
    }
    class Group
    {
        public DataTable group = new DataTable("Group");
        public DataColumn group_id = new DataColumn("group_id", typeof(int));
        public DataColumn group_name = new DataColumn("group_name", typeof(string));
    }
    class Subject
    {
        public DataTable subject = new DataTable("Subject");
        public DataColumn subject_id = new DataColumn("Subject_id", typeof(int));
        public DataColumn subject_name = new DataColumn("Subject_name", typeof(string));
        public DataColumn group_id = new DataColumn("Group_id", typeof(int));
    }

    class Root
    {
        static void EnumerateTable(DataTable dt)
        {
            var buffer = new System.Text.StringBuilder();
            foreach (DataColumn dc in dt.Columns)

            {
                buffer.AppendFormat("{0,15} ", dc.ColumnName);
            }

            buffer.Append("\r\n");
            foreach (DataRow dr in dt.Rows)

            {
                foreach (DataColumn dc in dt.Columns)

                {
                    buffer.AppendFormat("{0,15}", dr[dc]);
                }

                buffer.Append("\r\n");
            }

            Console.Write(dt.TableName + "\n" + buffer.ToString() + "\n");
        }
        static private void EnumerateView(DataView view)
        {
            var buffer = new System.Text.StringBuilder();
            foreach (DataColumn dc in view.Table.Columns)

            {
                buffer.AppendFormat("{0,15} ", dc.ColumnName);
            }

            buffer.Append("\r\n");
            foreach (DataRowView dr in view)

            {
                foreach (DataColumn dc in view.Table.Columns)

                {
                    buffer.AppendFormat("{0,15} ", dr.Row[dc]);
                }

                buffer.Append("\r\n");
            }

            Console.Write(view.Table.TableName + "\n" + buffer.ToString() + "\n");
        }
        //
        static void PrintValues(DataSet ds)
        {
            var buffer = new System.Text.StringBuilder();
            foreach (DataTable dt in ds.Tables)

            {
                foreach (DataColumn dc in dt.Columns)

                {
                    buffer.AppendFormat("{0,15} ", dc.ColumnName);
                }

                buffer.Append("\r\n");
                foreach (DataRow dr in dt.Rows)

                {
                    foreach (DataColumn dc in dt.Columns)

                    {
                        buffer.AppendFormat("{0,15}", dr[dc]);
                    }

                    buffer.Append("\r\n");
                }

                Console.Write(dt.TableName + "\n" + buffer.ToString() + "\n");
            }
        }
        //
        static void Main(string[] args)
        {
            DataSet dataset = new DataSet("DataSet");
            //
            DataTable subjectDTable = dataset.Tables.Add("Subject");
            DataColumn subject_id = new DataColumn("subject_id", typeof(int));
            DataColumn subject_name = new DataColumn("subject_name", typeof(string));

            subject_id.Unique = true;
            subject_id.AllowDBNull = false;
            subject_id.Caption = "subject_id";
            subjectDTable.Columns.Add(subject_id);

            subjectDTable.PrimaryKey = new DataColumn[] { subjectDTable.Columns["subject_id"] };

            subject_name.MaxLength = 23;
            subject_name.AllowDBNull = false;
            subject_name.Caption = "subject_name";
            subjectDTable.Columns.Add(subject_name);
            //
            DataTable groupDTable = dataset.Tables.Add("Group");
            DataColumn group_id = new DataColumn("group_id", typeof(int));
            DataColumn group_name = new DataColumn("group_name", typeof(string));
            DataColumn subjects_id = new DataColumn("subjects_id", typeof(int));

            group_id.Unique = true;
            group_id.AllowDBNull = false;
            group_id.Caption = "GROUP_ID";
            groupDTable.Columns.Add(group_id);

            groupDTable.PrimaryKey = new DataColumn[] { groupDTable.Columns["group_id"] };

            group_id.AutoIncrement = true;
            group_id.AutoIncrementSeed = -1;
            group_id.AutoIncrementStep = -1;

            group_name.MaxLength = 23;
            group_id.AllowDBNull = false;
            group_id.Caption = "GROUP_NAME";
            groupDTable.Columns.Add(group_name);

            subjects_id.AllowDBNull = false;
            subjects_id.Caption = "subjects_id";
            groupDTable.Columns.Add(subjects_id);
            //
            DataTable studentDTable = dataset.Tables.Add("Student");
            DataColumn student_id = new DataColumn("student_id", typeof(int));
            DataColumn student_name = new DataColumn("student_name", typeof(string));
            DataColumn student_surname = new DataColumn("student_surname", typeof(string));
            DataColumn groups_id = new DataColumn("groups_id", typeof(int));

            student_id.Unique = true;
            student_id.AllowDBNull = false;
            student_id.Caption = "student_ID";
            studentDTable.Columns.Add(student_id);

            studentDTable.PrimaryKey = new DataColumn[] { studentDTable.Columns["student_id"] };

            student_name.MaxLength = 23;
            student_name.AllowDBNull = false;
            student_name.Caption = "student_NAME";
            studentDTable.Columns.Add(student_name);

            student_surname.MaxLength = 23;
            student_surname.AllowDBNull = false;
            student_surname.Caption = "student_SURNAME";
            studentDTable.Columns.Add(student_surname);

            groups_id.AllowDBNull = false;
            groups_id.Caption = "GROUPS_ID";
            studentDTable.Columns.Add(groups_id);
            //
            dataset.Relations.Add("subject_group", subjectDTable.Columns["subject_id"], groupDTable.Columns["subjects_id"]);
            dataset.Relations.Add("group_student", groupDTable.Columns["group_id"], studentDTable.Columns["groups_id"]);
            //
            subjectDTable.Rows.Add(1, "OOP");
            subjectDTable.Rows.Add(2, "POP");
            subjectDTable.Rows.Add(3, "3D");
            subjectDTable.Rows.Add(4, "Circuitry");
            subjectDTable.Rows.Add(5, "BD");
            subjectDTable.AcceptChanges();
            //
            groupDTable.Rows.Add(1, "KN-390", 1);
            groupDTable.Rows.Add(2, "KN-391", 4);
            groupDTable.Rows.Add(3, "LN-392", 2);
            groupDTable.Rows.Add(4, "FN-393", 5);
            groupDTable.Rows.Add(5, "DN-394", 3);
            groupDTable.AcceptChanges();
            //
            studentDTable.Rows.Add(1, "Andrij", "Rapavyy", 2);
            studentDTable.Rows.Add(2, "Uliana", "Mikhotska", 2);
            studentDTable.Rows.Add(3, "Grynda", "Volodja", 1);
            studentDTable.Rows.Add(4, "Dmytro", "Tymchyk", 3);
            studentDTable.Rows.Add(5, "Ira", "Vasiliv", 4);
            studentDTable.AcceptChanges();
            //
            dataset.AcceptChanges();
            EnumerateTable(subjectDTable);
            EnumerateTable(groupDTable);
            EnumerateTable(studentDTable);
            Console.WriteLine("**************************** Sorting & Filtering ****************************\n");
            //
            DataView viewSort_st = new DataView(studentDTable);
            viewSort_st.Sort = "student_surname ASC";
            DataView viewFilter_n = new DataView(studentDTable);
            viewFilter_n.RowFilter = "student_surname like 'R%'";

            EnumerateView(viewSort_st);
            EnumerateView(viewFilter_n);
            Console.WriteLine("********************************** Editing **********************************\n");

            studentDTable.Rows.Add(6, "Sergij", "Petruk", 5);
            studentDTable.Rows.RemoveAt(2);
            studentDTable.LoadDataRow(new object[] {4, "Vasyl", "Ivasiv", 3}, LoadOption.OverwriteChanges);
            EnumerateTable(studentDTable);

            groupDTable.Rows.Add(6, "XN-392", 5);
            groupDTable.Rows.RemoveAt(2);
            groupDTable.LoadDataRow(new object[] {4, "YN-391", 2}, LoadOption.OverwriteChanges);
            EnumerateTable(groupDTable);

            subjectDTable.Rows.Add(6, "Science");
            subjectDTable.Rows.RemoveAt(1);
            subjectDTable.LoadDataRow(new object[] {1, "English"}, LoadOption.OverwriteChanges);
            EnumerateTable(subjectDTable);
/*  Some crap happened here!!!
            DataSet newDataSet = dataset.GetChanges();
                        PrintValues(newDataSet);
*/
            Console.ReadLine();

        }
    }
}