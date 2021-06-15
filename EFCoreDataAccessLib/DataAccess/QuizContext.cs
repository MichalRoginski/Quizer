using EFCoreDataAccessLib.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFCoreDataAccessLib.DataAccess
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions options) : base(options) { }
        public DbSet<Quiz> quizzes { get; set; }
        public DbSet<Question> questions { get; set; }
        public void AddQQ(int questionid, int quizid)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Quizer;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddQQ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@questionid", questionid);
                cmd.Parameters.AddWithValue("@quizid", quizid);
                con.Open();
                con.Close();
            }
        }
        public void RemoveQQ(int questionid, int quizid)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Quizer;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("RemoveQQ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@questionid", questionid);
                cmd.Parameters.AddWithValue("@quizid", quizid);
                con.Open();
                con.Close();
            }
        }
        public List<int> GetQQ(int quizid)
        {
            List<int> list = new List<int>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Quizer;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetQQ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@quizid", quizid);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(Convert.ToInt32(rdr["questionsid"]));
                }
                con.Close();
            }
            return list;
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Quiz>()
        //        .HasMany(p => p.questions)
        //        .WithMany(p => p.quizes)
        //        .UsingEntity<QuizQuestion>(
        //            j => j
        //                .HasOne(pt => pt.quiz)
        //                .WithMany(t => t.quizQuestions)
        //                .HasForeignKey(pt => pt.quizId),
        //            j => j
        //                .HasOne(pt => pt.question)
        //                .WithMany(p => p.quizQuestions)
        //                .HasForeignKey(pt => pt.questionId),
        //            j =>
        //            {
        //                j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        //                j.HasKey(t => new { t.questionId, t.quizId });
        //            });
        //}
    }
}
