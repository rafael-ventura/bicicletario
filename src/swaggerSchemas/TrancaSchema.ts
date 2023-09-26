/**
 * @swagger
 * components:
 *   schemas:
 *     Tranca:
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
 *         estado:
 *           type: string
 *         localizacaoAtual:
 *           type: string
 */

/**
 * @swagger
 * /trancas:
 *   post:
 *     summary: Adiciona uma nova tranca
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Tranca'
 *     responses:
 *       '201':
 *         description: Tranca adicionada com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *   get:
 *     summary: Lista todas as trancas
 *     responses:
 *       '200':
 *         description: Lista de trancas
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Tranca'
 *       '401':
 *         description: Não autorizado
 * /trancas/{id}:
 *   put:
 *     summary: Atualiza os dados de uma tranca
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
 *             $ref: '#/components/schemas/Tranca'
 *     responses:
 *       '200':
 *         description: Tranca atualizada com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *       '404':
 *         description: Tranca não encontrada
 *   delete:
 *     summary: Remove uma tranca
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *     responses:
 *       '204':
 *         description: Tranca removida com sucesso
 *       '404':
 *         description: Tranca não encontrada
 */
