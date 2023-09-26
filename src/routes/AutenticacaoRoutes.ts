
/*interface AuthRequest extends Request {
  body: { auth: IAuth };
}*/

/**
 * @swagger
 * tags:
 *   name: Autenticacao
 *   description: Gerenciamento de autenticação.
 */

/**
 * @swagger
 * /autenticacao:
 *   post:
 *     summary: Autentica um usuário
 *     tags: [Autenticacao]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Autenticacao'
 *           example:
 *             usuarioId: "1"
 *             senha: "senha123"
 *     responses:
 *       200:
 *         description: Autenticação bem-sucedida
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Autenticacao'
 *       400:
 *         description: Dados de entrada inválidos
 *         content:
 *           application/json:
 *             example:
 *               error: "Informações de autenticação estão incompletas ou inválidas"
 *       401:
 *         description: Autenticação falhou
 *         content:
 *           application/json:
 *             example:
 *               error: "Usuário ou senha incorretos"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível autenticar o usuário"
 */
/*async function authenticate(req: AuthRequest, res: Response) {
  const { auth } = req.body;
  try {
    const authenticatedUser = await AuthService.authenticate(auth);
    return res.status(HttpStatusCodes.OK).json(authenticatedUser);
  } catch (error) {
    return res.status(HttpStatusCodes.UNAUTHORIZED).json({ error: "Usuário ou senha incorretos" });
  }
}*/

/*
export default {
  authenticate,
} as const;
*/
