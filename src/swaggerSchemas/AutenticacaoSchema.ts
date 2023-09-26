/**
 * @swagger
 * components:
 *   schemas:
 *     Login:
 *       type: object
 *       properties:
 *         email:
 *           type: string
 *         senha:
 *           type: string
 *     RecuperacaoSenha:
 *       type: object
 *       properties:
 *         email:
 *           type: string
 */

/**
 * @swagger
 * /login:
 *   post:
 *     summary: Realiza o login do usuário
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Login'
 *     responses:
 *       '200':
 *         description: Login realizado com sucesso
 *       '401':
 *         description: Credenciais inválidas
 * /recuperacao-senha:
 *   post:
 *     summary: Solicita a recuperação de senha
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/RecuperacaoSenha'
 *     responses:
 *       '200':
 *         description: Solicitação de recuperação de senha realizada com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *       '404':
 *         description: Usuário não encontrado
 */
