namespace smartfy.portal_api.presentation.UI.Web.Helpers
{
    public class ModalHelper
    {
        /// <summary>
        /// Helper que abstrai a criação de html para modal bootstrap
        /// </summary>
        private static string ModalHtml { get; set; }

        /// <summary>
        /// Script para abrir o modal
        /// </summary>
        private static readonly string ShowScript =
            $"<script type='text/javascript'>" +
                "$(document).ready(()=>{" +
                "$('#ModalHelper').modal('show');" +
                    "});" +
            "</script>";


        /// <summary>
        /// Mostra o modal
        /// </summary>
        /// <param name="titulo">Titulo do modal</param>
        /// <param name="corpo">Texto descritivo do corpo do modal</param>
        /// <param name="tipoModal">
        ///     Tipo do modal, menssagem ou confirm dialog yes no
        ///         botão "yes" chama a função ModalYes() que precisa ser implementada no script da pagina chamadora
        ///         botão "no" chama a função ModalNo() que precisa ser implementada no script da pagina chamadora
        ///         botão "ok" chama a função ModalOk() que precisa ser implementada no script da pagina chamadora
        /// </param>
        public static void ShowModal(string titulo, string corpo, string tipoModal, string cssClass = "")
        {
            ModalHtml =
                $"<div id='ModalHelper' class='modal fade' tabindex='-1' role='dialog' aria-labelledby='gridSystemModalLabel'>" +
                $"    <div class='modal-dialog' role='document'>" +
                $"        <div class='modal-content'>" +
                $"          <div class='modal-header {cssClass}'>" +
                $"              <h4 class='modal-body' id='gridSystemModalLabel'>{titulo}</h4>" +
                $"          </div>" +
                $"          <div class='modal-body'>" +
                $"              {corpo}" +
                $"          </div>" +
                $"          <div class='modal-footer'>" +
                $"              {tipoModal}" +
                $"          </div>" +
                $"        </div>" +
                $"    </div>" +
                $"</div>" +
                $"{ShowScript}";
        }

        /// <summary>
        /// Esse método deve ser chamado no layout da view 
        /// </summary>
        /// <returns></returns>
        public static string GetModal()
        {
            return ModalHtml;
        }

        /// <summary>
        /// utilizado pela view para limpar o modal depois de mostrado
        /// </summary>
        /// <returns></returns>
        public static object ClearModal()
        {
            ModalHtml = "";
            return null;
        }

        /// <summary>
        /// Tipos de Modal
        /// </summary>
        public static class Types
        {
            public static readonly string Message =
                $"<button type='button' class='btn btn-default' data-dismiss='modal' onclick='ModalOk();'>Ok</button>";

            public static readonly string YesNo =
                "<button type='button' class='btn btn-primary' onclick='ModalYes();'>Sim</button>" +
                           "<button type='button' class='btn btn-default' data-dismiss='modal' onclick='ModalNo();'>Não</button>";
        }

        /// <summary>
        /// Classe que define o estilo do Header do modal
        /// </summary>
        public static class CssClass
        {
            public static readonly string Success = "bg-success";
            public static readonly string Danger = "bg-danger";
            public static readonly string Info = "bg-info";
            public static readonly string Primary = "bg-primary";
            public static readonly string Warning = "bg-warning";

        };
    }
}
