/**
 * @swagger
 * components:
 *   schemas:
 *     Totem:
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
 * /totens:
 *   post:
 *     summary: Adiciona um novo totem
 *     tags: [Totem]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Totem'
 *     responses:
 *       201:
 *         description: Totem adicionado com sucesso
 *       400:
 *         description: Dados de entrada inválidos
 *   get:
 *     summary: Lista todos os totens
 *     tags: [Totem]
 *     responses:
 *       200:
 *         description: Lista de totens
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Totem'
 *       404:
 *         description: Nenhum totem encontrado
 */

/**
 * @swagger
 * /totens/{id}:
 *   put:
 *     summary: Atualiza o status de um totem
 *     tags: [Totem]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID do totem.
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Totem'
 *     responses:
 *       200:
 *         description: Totem atualizado com sucesso
 *       404:
 *         description: Totem não encontrado
 *   delete:
 *     summary: Remove um totem da rede
 *     tags: [Totem]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID do totem.
 *     responses:
 *       204:
 *         description: Totem removido com sucesso
 *       404:
 *         description: Totem não encontrado
 */
