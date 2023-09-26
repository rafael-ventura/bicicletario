/**
 * @swagger
 * components:
 *   schemas:
 *     Funcionario:
 *       type: object
 *       properties:
 *         id:
 *           type: string
 *         matricula:
 *           type: string
 *         nome:
 *           type: string
 *         idade:
 *           type: number
 *         funcao:
 *           type: string
 *         cpf:
 *           type: string
 */

/**
 * @swagger
 * /funcionarios:
 *   post:
 *     summary: Adiciona um novo funcionário
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Funcionario'
 *     responses:
 *       '201':
 *         description: Funcionário adicionado com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *   get:
 *     summary: Lista todos os funcionários
 *     responses:
 *       '200':
 *         description: Lista de funcionários
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Funcionario'
 *       '401':
 *         description: Não autorizado
 * /funcionarios/{id}:
 *   put:
 *     summary: Atualiza os dados de um funcionário
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Funcionario'
 *     responses:
 *       '200':
 *         description: Funcionário atualizado com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *       '404':
 *         description: Funcionário não encontrado
 *   delete:
 *     summary: Remove um funcionário
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *     responses:
 *       '204':
 *         description: Funcionário removido com sucesso
 *       '404':
 *         description: Funcionário não encontrado
 */
