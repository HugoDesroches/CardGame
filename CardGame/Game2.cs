using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Game2 : Form
    {
        #region Param
        GameObject gameSetting = new GameObject();
        public bool CreateServer = false;
        #endregion

        #region First Load
        public Game2()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            //set error Call back
            gameSetting.SetCallBack(ErrorPage, TextPage, ChangeTurn);
        }

        private void Game2_Load(object sender, EventArgs e)
        {
            gameSetting.SetServerIpPort("localhost", 8080);
            if (this.CreateServer)
            {
                Task.Delay(100).ContinueWith(t => gameSetting.CreateServer());
            }
            else
            {
                Task.Delay(100).ContinueWith(t => gameSetting.JoinOnline());
            }
        }
        #endregion

        #region Text
        #region Error
        private bool ErrorPage(bool val = true, string message = "Erreur")
        {
            SetText(message, this.ErrorLabel, this.PanelError, val);
            return true;
        }

        private void PanelError_Click(object sender, EventArgs e)
        {
            this.ErrorPage(false);
        }

        private void ErrorLabel_Click(object sender, EventArgs e)
        {
            this.ErrorPage(false);
        }
        #endregion
        #region Normal Text
        delegate void SetTextCallback(string text, object objectToChange, object Panel, bool visible);

        private void SetText(string text, object objectToChange, object Panel, bool visible)
        {
            var toChange = (Label)objectToChange;
            if (toChange.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, toChange, Panel, visible });
            }
            else
            {
                toChange.Text = text;
                if(visible != toChange.Visible)
                    Animation.Animate((Control)Panel, Animation.Effect.Slide, 200, 90);
                
            }
        }
        private bool TextPage(bool val = true, string message = "Text")
        {
            SetText(message, this.TextMessage, this.MessagePanel, val);
            return true;
        }
        #endregion

        #endregion

        private bool ChangeTurn (bool myTurn)
        {
            SetObject(btnPassTurn, myTurn);
            return true;
        }

        delegate void SetObjectCallback(object objectToChange, bool visible);

        private void SetObject(object objectToChange, bool visible)
        {
            var toChange = (Control)objectToChange;
            if (toChange.InvokeRequired)
            {
                SetObjectCallback d = new SetObjectCallback(SetObject);
                this.Invoke(d, new object[] { objectToChange, visible });
            }
            else
            {
                ((Control)objectToChange).Visible = visible;

            }
        }

        private void TextMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnPassTurn_Click(object sender, EventArgs e)
        {
            gameSetting.PassTurn();
        }
    }
}
