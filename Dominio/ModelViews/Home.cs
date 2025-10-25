using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_crud_veiculos_dotnet.Dominio.ModelView {
    public class Home {

        string _html = @"
        <html>
            <head>
                <title>API de Veículos</title>
                <style>
                    body { font-family: Arial; background-color: #f8f9fa; text-align: center; padding: 50px; }
                    h1 { color: #0078D7; }
                    p { color: #333; }
                    .box { background: white; padding: 20px; border-radius: 10px; display: inline-block; box-shadow: 0 0 10px rgba(0,0,0,0.1); }
                </style>
            </head>
            <body>
                <div class='box'>
                    <h1> 🚗 API de Cadastro de Veículos 🚗</h1>
                    <p>API respondendo com sucesso!</p>
                    <p style='font-size:20px;'>Documentação: <a href='/swagger'> AQUI</a> </p>
                </div>
            </body>
        </html>
    ";

        public string Html => _html;
    }
}