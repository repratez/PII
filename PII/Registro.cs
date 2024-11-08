﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PII
{
    public partial class registro : Form
    {

        Conexao conexao = new Conexao();
        public registro()
        {

            InitializeComponent();
            dataGridAlunos.RowPostPaint += dataGridAlunos_RowPostPaint;
        }

        bool menuExpand = false;

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {

            if (sidebarExpand)
            {
                sideBar.Width -= 5;
                if (sideBar.Width <= 43)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sideBar.Width += 5;
                if (sideBar.Width >= 209)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }

        }

        private void dataGridAlunos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Verifica se a linha atual é a última linha
            if (e.RowIndex == dataGridAlunos.Rows.Count - 1)
            {
                // Define a cor e a espessura da linha
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    // Posição inicial e final da linha vermelha
                    int xStart = e.RowBounds.Left;
                    int yPosition = e.RowBounds.Bottom - 1;
                    int xEnd = e.RowBounds.Right;

                    // Desenha a linha vermelha abaixo da última linha
                    e.Graphics.DrawLine(pen, xStart, yPosition, xEnd, yPosition);
                }
            }
        }


        private void menuTransition_Tick(object sender, EventArgs e)
        {

            if (menuExpand == false)
            {
                menuContainer.Height += 10;

                if (menuContainer.Height >= 179)
                {
                    menuTransition.Stop();
                    menuExpand = true;

                }

            }

            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 44)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }



            }

        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void registro_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> cursos = conexao.ObterCursos();
            comboBoxCurso.DisplayMember = "Value";
            comboBoxCurso.ValueMember = "Key";
            comboBoxCurso.DataSource = cursos;

            // Carrega os dados dos alunos
            CarregarDadosAlunos();

            // Configura o estilo do DataGridView
            ConfigurarEstiloDataGrid();
            AjustarTamanhoColunas();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text.Trim();
                string dataNascimentoStr = txtData.Text.Trim();
                DateTime dataNascimento;

                if (!DateTime.TryParse(dataNascimentoStr, out dataNascimento))
                {
                    MessageBox.Show("Data de nascimento inválida. Por favor, insira uma data válida.");
                    return;
                }

                int idCurso = (int)comboBoxCurso.SelectedValue;
                string endereco = txtEndereco.Text.Trim();
                string email = txtEmail.Text.Trim();
                string matricula = txtMatricula.Text.Trim();

                conexao.InserirRegistro(nome, dataNascimento, idCurso, endereco, email, matricula);

                MessageBox.Show("Registro inserido com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir registro: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregarDadosAlunos()
        {
            DataTable alunos = conexao.ObterAlunos();
            if (alunos.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum aluno encontrado.");
            }
            else
            {
                dataGridAlunos.DataSource = alunos; // Exibe os dados no DataGridView
            }
        }

        private void AjustarTamanhoColunas()
        {
            // Ajusta a largura das colunas para se adaptar ao conteúdo
            dataGridAlunos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAlunos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridAlunos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridAlunos.ColumnHeadersHeight = 35; // Altura do cabeçalho
        }

        private void ConfigurarEstiloDataGrid()
        {
            
                dataGridAlunos.EnableHeadersVisualStyles = false; // Permite a customização dos cabeçalhos

                // Cor de fundo e fonte dos cabeçalhos
                dataGridAlunos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
                dataGridAlunos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridAlunos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

                // Estilo das células
                dataGridAlunos.DefaultCellStyle.Font = new Font("Arial", 12);
                dataGridAlunos.DefaultCellStyle.BackColor = Color.White;
                dataGridAlunos.DefaultCellStyle.ForeColor = Color.Black;
                dataGridAlunos.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridAlunos.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Bordas e alinhamento
                dataGridAlunos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridAlunos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dataGridAlunos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

              
            }

        

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UNIFENAS_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }

        private void Anexar_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 reg3 = new Form3();
            reg3.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registro reg = new registro();
            reg.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            RegistroProfessores reg2 = new RegistroProfessores();
            reg2.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
   
 

