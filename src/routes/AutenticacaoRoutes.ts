/**
 * @swagger
 * /login:
 *   post:
 *     summary: Realiza o login do usuário
 *     tags: [Autenticacao]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/LoginRequest'
 *     responses:
 *       '200':
 *         description: Login realizado com sucesso
 *       '401':
 *         description: Credenciais inválidas
 */

/**
 * @swagger
 * /recuperacao-senha:
 *   post:
 *     summary: Solicita a recuperação de senha
 *     tags: [Autenticacao]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/RecuperacaoSenhaRequest'
 *     responses:
 *       '200':
 *         description: Email de recuperação de senha enviado
 *       '404':
 *         description: Usuário não encontrado
 */
