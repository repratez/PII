﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace PII
{
    public partial class Ouvidoria : Form
    {
        public Ouvidoria()
        {
            InitializeComponent();
            // Configurações para o DataGridView
            dataGridView1.ColumnHeadersVisible = false; // Remove os cabeçalhos
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleção da linha inteira

            // Remover as linhas de grade
            dataGridView1.GridColor = System.Drawing.Color.White;

            // Remover as linhas de bordas da célula
            dataGridView1.BorderStyle = BorderStyle.None;

            // Desabilitar a ordenação nas colunas
            dataGridView1.AllowUserToOrderColumns = false;

            // Desabilitar edição nas células
            dataGridView1.AllowUserToAddRows = false;  // Desabilita a linha de "nova linha"
            dataGridView1.ReadOnly = true; // Torna todas as células de somente leitura
        }

        private void Ouvidoria_Load(object sender, EventArgs e)
        {
            // Configurações adicionais, se necessário, podem ser feitas aqui
        }

        private void menu_Click(object sender, EventArgs e)
        {
            // Lógica para o clique no menu (se necessário)
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Fecha a janela ao clicar no pictureBox2
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Abre o OpenFileDialog para o usuário selecionar um arquivo
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Verifica se o usuário selecionou um arquivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Recupera o nome do arquivo e a extensão
                string fileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                string fileExtension = System.IO.Path.GetExtension(openFileDialog.FileName);

                // Verifica se as colunas já foram criadas. Se não, cria as colunas.
                if (dataGridView1.Columns.Count == 0)
                {
                    // Adiciona as colunas de nome do arquivo e extensão
                    dataGridView1.Columns.Add("FileName", "Nome do Arquivo");

                }

                // Adiciona o nome do arquivo e extensão no DataGridView
                dataGridView1.Rows.Add(fileName, fileExtension);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            popup homeAlunoForm = new popup(this);

            // Exibe o pop-up
            homeAlunoForm.ShowDialog();
        }

        public void LimparCampos()
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Text = string.Empty;
                }
                else if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndex = -1; // Limpar ComboBox
                }
                else if (control is CheckBox)
                {
                    (control as CheckBox).Checked = false; // Desmarcar CheckBox
                }
                else if (control is RadioButton)
                {
                    (control as RadioButton).Checked = false; // Desmarcar RadioButton
                }
                else if (control is GroupBox)
                {
                    // Limpar os controles dentro do GroupBox
                    foreach (Control groupControl in (control as GroupBox).Controls)
                    {
                        if (groupControl is TextBox)
                        {
                            (groupControl as TextBox).Text = string.Empty; // Limpar TextBox dentro do GroupBox
                        }
                        else if (groupControl is ComboBox)
                        {
                            (groupControl as ComboBox).SelectedIndex = -1; // Limpar ComboBox dentro do GroupBox
                        }
                        else if (groupControl is CheckBox)
                        {
                            (groupControl as CheckBox).Checked = false; // Desmarcar CheckBox dentro do GroupBox
                        }
                        else if (groupControl is RadioButton)
                        {
                            (groupControl as RadioButton).Checked = false; // Desmarcar RadioButton dentro do GroupBox
                        }
                    }



                }

                // Limpar DataGridView (remover todas as linhas)
                dataGridView1.Rows.Clear();  // Isso remove todas as linhas de dados




            }
        }

        bool sidebarExpand = true;


        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
        bool menuExpand = false;
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if(menuExpand == false)
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

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                sideBar.Width -= 5;
                if (sideBar.Width <= 43)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }else
            {
                sideBar.Width += 5;
                if (sideBar.Width >= 209)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Solicitar_aulas solicitar_Aulas = new Solicitar_aulas();
            solicitar_Aulas.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomeAluno homeAluno = new HomeAluno();
            homeAluno.Show();
            
        }
    }
}

