/**
 * @swagger
 * components:
 *   schemas:
 *     Tranca:
 *       type: object
 *       properties:
 *         id:
 *           type: string
 *         status:
 *           type: string
 *         localizacao:
 *           $ref: '#/components/schemas/Localizacao'
 */

/**
 * @swagger
 * /trancas:
 *   post:
 *     summary: Adiciona uma nova tranca
 *     tags: [Tranca]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Tranca'
 *     responses:
 *       201:
 *         description: Tranca adicionada com sucesso
 *       400:
 *         description: Dados de entrada inválidos
 *   get:
 *     summary: Lista todas as trancas
 *     tags: [Tranca]
 *     responses:
 *       200:
 *         description: Lista de trancas
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Tranca'
 *       404:
 *         description: Nenhuma tranca encontrada
 */

/**
 * @swagger
 * /trancas/{id}:
 *   put:
 *     summary: Atualiza o status de uma tranca
 *     tags: [Tranca]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID da tranca.
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Tranca'
 *     responses:
 *       200:
 *         description: Tranca atualizada com sucesso
 *       404:
 *         description: Tranca não encontrada
 *   delete:
 *     summary: Remove uma tranca da rede
 *     tags: [Tranca]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID da tranca.
 *     responses:
 *       204:
 *         description: Tranca removida com sucesso
 *       404:
 *         description: Tranca não encontrada
 */
