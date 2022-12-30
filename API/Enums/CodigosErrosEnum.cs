using System.ComponentModel;

namespace API.Enums
{
    public enum CodigosErrosEnum
    {
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 100 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Description("Já existe outro usuário cadastrado com este e-mail ou nome de usuário")]
        UsuarioExistente = 101,

        [Description("Tipo de usuário não permitido")]
        TipoUsuarioNaoPermitido = 102,

        [Description("Tipo de usuário não encontrado")]
        TipoUsuarioNaoEncontrado = 103,

        [Description("Os requisitos de senha não foram cumpridos. A senha deve ser mais segura")]
        RequisitosSenhaNaoCumprido = 104,

        [Description("O nome completo ou nome de usuário não atingem o mínimo de caracteres necessários")]
        RequisitosNome = 105,

        [Description("E-mail inválido")]
        EmailInvalido = 106,

        [Description("O usuário ou senha estão incorretos")]
        UsuarioSenhaIncorretos = 107,

        [Description("Esta conta está desativada")]
        ContaDesativada = 108,

        [Description("Este usuário não foi encontrado")]
        UsuarioNaoEncontrado = 109,

        [Description("Este código está expirado")]
        CodigoExpirado = 1110,

        [Description("As senhas não se coincidem")]
        SenhasNaoCoincidem = 111,

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 200 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Description("Processo concluído com sucesso")]
        OK = 200,

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 400 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Description("Não autorizado")]
        NaoAutorizado = 403,

        [Description("Dado não encontrado")]
        NaoEncontrado = 404,

        [Description("Refresh token inválido")]
        RefreshTokenInvalido = 411,

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 500 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Description("Processo abortado pois houve um erro interno")]
        ErroInterno = 500,

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=- 500 =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Description("Processo abortado. Parece que a mensagem está vazia")]
        MensagemVazia = 600,

        [Description("Palavra desconhecida")]
        PalavraDesconhecida = 601
    }
}
