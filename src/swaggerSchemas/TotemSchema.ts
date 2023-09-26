/**
 * @swagger
 * components:
 *   schemas:
 *     Totem:
 *       type: object
 *       properties:
 *         id:
 *           type: string
 *         marca:
 *           type: string
 *         modelo:
 *           type: string
 *         anoAquisicao:
 *           type: string
 *         localizacaoAtual:
 *           type: string
 */

/**
 * @swagger
 * /totens:
 *   post:
 *     summary: Adiciona um novo totem
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Totem'
 *     responses:
 *       '201':
 *         description: Totem adicionado com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *   get:
 *     summary: Lista todos os totens
 *     responses:
 *       '200':
 *         description: Lista de totens
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Totem'
 *       '401':
 *         description: Não autorizado
 * /totens/{id}:
 *   put:
 *     summary: Atualiza os dados de um totem
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
 *             $ref: '#/components/schemas/Totem'
 *     responses:
 *       '200':
 *         description: Totem atualizado com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *       '404':
 *         description: Totem não encontrado
 *   delete:
 *     summary: Remove um totem
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *     responses:
 *       '204':
 *         description: Totem removido com sucesso
 *       '404':
 *         description: Totem não encontrado
 */
