using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplicationProva
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              CarregarDadosPagina();
        }

        protected void btnsalvar_Click(object sender, EventArgs e)
        {
            if (txtano.Text == "" || txtdescricao.Text == "")
            {
                lblmsg.Text = "Preencha todos os campos!";
            }
            else
            {
                string descricao = txtdescricao.Text;
                int ano = Convert.ToInt32(txtano.Text);
                Figurinha f = new Figurinha() { descricao = descricao, ano = ano };
                ProvaEntities contextProva = new ProvaEntities();
                contextProva.Figurinha.Add(f);
                contextProva.SaveChanges();
                lblmsg.Text = "Registro Inserido!";
                Clear();
                CarregarDadosPagina();
            }
        }

        private void Clear()
        {
            txtdescricao.Text = "";
            txtano.Text = "";
        }

        private void CarregarDadosPagina()
        {
            ProvaEntities contextProva = new ProvaEntities();
            List<Figurinha> lstfigurinha = contextProva.Figurinha.ToList<Figurinha>();

            GVDados.DataSource = lstfigurinha;
            GVDados.DataBind();
        }


    }
}