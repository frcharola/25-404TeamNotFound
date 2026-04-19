namespace Formas_Aleatorias_Eventos_Delegados
{
    partial class View
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.botaoNovaForma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botaoNovaForma
            // 
            this.botaoNovaForma.Location = new System.Drawing.Point(12, 12);
            this.botaoNovaForma.Name = "botaoNovaForma";
            this.botaoNovaForma.Size = new System.Drawing.Size(122, 57);
            this.botaoNovaForma.TabIndex = 0;
            this.botaoNovaForma.Text = "Nova Forma";
            this.botaoNovaForma.UseVisualStyleBackColor = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.botaoNovaForma);
            this.Name = "View";
            this.Text = "Gerador de Formas aleatórias";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botaoNovaForma;
    }
}

