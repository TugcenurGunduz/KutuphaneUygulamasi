using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace KutupHane_Uygulamasi
{
    public partial class Form1 : Form
    {
    
        SqlConnection sqlcon;
        SqlCommand sqlcom;
        SqlDataAdapter sqlda;


        string con_string;

        string sql_string;

        DataTable dt;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  
        {
            con_string = "Data Source=DESKTOP-U1FQPLE\\SQLSERVER2017EXP;Initial Catalog=Kutuphane;Integrated Security=True";
      
            sqlcon = new SqlConnection(con_string);
            sqlcon.Open();

            sql_string = " select * from kitap";
            sqlcom = new SqlCommand(sql_string, sqlcon);
            sqlda = new SqlDataAdapter(sqlcom);


            dt = new DataTable();
            sqlda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hangi_satir = e.RowIndex;
            DataGridViewRow dr = new DataGridViewRow();
            dr = dataGridView1.Rows[hangi_satir];
            textBox1.Text = dr.Cells[0].Value.ToString();
            textBox2.Text = dr.Cells[1].Value.ToString();
            textBox3.Text = dr.Cells[2].Value.ToString();
            textBox4.Text = dr.Cells[3].Value.ToString();
            textBox5.Text = dr.Cells[4].Value.ToString();
            textBox6.Text = dr.Cells[5].Value.ToString();
            textBox7.Text = dr.Cells[6].Value.ToString();
            textBox8.Text = dr.Cells[7].Value.ToString();
          

        }

        private void button2_Click(object sender, EventArgs e)  
        {
            con_string = "Data Source=DESKTOP-U1FQPLE\\SQLSERVER2017EXP;Initial Catalog=Kutuphane;Integrated Security=True";
            sqlcon = new SqlConnection(con_string);
            sqlcon = new SqlConnection(con_string);

            sqlcon.Open();

            sql_string = "";
            sql_string =  sql_string + "insert into kitap (Ad,yazar_Adi,Konu,fiyat,Barkod,sayfa_sayisi,tur) values(";
            sql_string = sql_string + "'" + textBox2.Text + "', ";   //Ad
            sql_string = sql_string + "'" + textBox3.Text + "', ";   // yazar adi
            sql_string = sql_string + "'" + textBox4.Text + "', ";   //konu
            sql_string = sql_string + " " + textBox5.Text + " , ";   //fiyat
            sql_string = sql_string + "'" + textBox6.Text + "', ";   //barkod
            sql_string = sql_string + " " + textBox7.Text + " , ";   //Sayfa_Sayisi
            sql_string = sql_string + "'" + textBox8.Text + "'  ";   //Tur
            sql_string = sql_string + ")";


            sqlcom = new SqlCommand(sql_string, sqlcon);
            sqlcom.ExecuteNonQuery();  // databaseye insert ediyor
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            con_string = "Data Source=DESKTOP-U1FQPLE\\SQLSERVER2017EXP;Initial Catalog=Kutuphane;Integrated Security=True";
            sqlcon = new SqlConnection(con_string);
            sqlcon.Open();

            sql_string = "";
            sql_string = sql_string + " delete from kitap where Id=" + textBox1.Text;


            sqlcom = new SqlCommand(sql_string, sqlcon);

            int kactane_etkilendi=sqlcom.ExecuteNonQuery();  // databaseye insert ediyor
            MessageBox.Show(kactane_etkilendi.ToString() + " kayıt silindi    idsi= " + textBox1.Text);
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            con_string = "Data Source=DESKTOP-U1FQPLE\\SQLSERVER2017EXP;Initial Catalog=Kutuphane;Integrated Security=True";
            sqlcon = new SqlConnection(con_string);
            sqlcon.Open();

            sql_string = "";
            sql_string = sql_string + "update kitap set ";
            sql_string = sql_string + "Ad="           + "'" + textBox2.Text + "' , ";   //Ad
            sql_string = sql_string + "Yazar_Adi="    + "'" + textBox3.Text + "' , ";   //Yazar_Adi
            sql_string = sql_string + "Konu="         + "'" + textBox4.Text + "' , ";   //konu
            sql_string = sql_string + "Fiyat="         + " " + textBox5.Text + "  , ";  //fiyat
            sql_string = sql_string + "Barkod="       + "'" + textBox6.Text + "' , ";   //barkod
            sql_string = sql_string + "Sayfa_Sayisi=" + " " + textBox7.Text + "  , ";   //sayfa sayisi
            sql_string = sql_string + "Tur="          + "'" + textBox8.Text + "'   ";   //tur

            sql_string = sql_string + " where  Id=" +  textBox1.Text;


            sqlcom = new SqlCommand(sql_string, sqlcon);
            int kactane_etkilendi=sqlcom.ExecuteNonQuery();  // databaseye update ediyor

            MessageBox.Show(kactane_etkilendi.ToString() + " kayıt duzeldi    idsi= " + textBox1.Text);
            button1_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kutuphaneDataSet.Kitap' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabiliriz.
            //this.kitapTableAdapter.Fill(this.kutuphaneDataSet.Kitap);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
