/**
 * @swagger
 * components:
 *   schemas:
 *     Funcionario:
 *       type: object
 *       properties:
 *         id:
 *           type: string
 *         nome:
 *           type: string
 *         cargo:
 *           type: string
 *         email:
 *           type: string
 */

/**
 * @swagger
 * /funcionarios:
 *   post:
 *     summary: Cadastra um novo funcionário
 *     tags: [Funcionario]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Funcionario'
 *     responses:
 *       201:
 *         description: Funcionário cadastrado com sucesso
 *       400:
 *         description: Dados de entrada inválidos
 *   get:
 *     summary: Lista todos os funcionários
 *     tags: [Funcionario]
 *     responses:
 *       200:
 *         description: Lista de funcionários
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Funcionario'
 *       404:
 *         description: Nenhum funcionário encontrado
 */

/**
 * @swagger
 * /funcionarios/{id}:
 *   put:
 *     summary: Atualiza os dados de um funcionário
 *     tags: [Funcionario]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID do funcionário.
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Funcionario'
 *     responses:
 *       200:
 *         description: Funcionário atualizado com sucesso
 *       404:
 *         description: Funcionário não encontrado
 *   delete:
 *     summary: Remove um funcionário
 *     tags: [Funcionario]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID do funcionário.
 *     responses:
 *       204:
 *         description: Funcionário removido com sucesso
 *       404:
 *         description: Funcionário não encontrado
 */
