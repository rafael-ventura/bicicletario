/**
 * @swagger
 * components:
 *   schemas:
 *     Cobranca:
 *       type: object
 *       properties:
 *         id:
 *           type: string
 *         idLocatario:
 *           type: string
 *         valor:
 *           type: number
 *         data:
 *           type: string
 *         hora:
 *           type: string
 *         detalhes:
 *           type: string
 */

/**
 * @swagger
 * /cobrancas:
 *   post:
 *     summary: Registra uma nova cobrança
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Cobranca'
 *     responses:
 *       '201':
 *         description: Cobrança registrada com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *   get:
 *     summary: Lista todas as cobranças
 *     responses:
 *       '200':
 *         description: Lista de cobranças
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Cobranca'
 *       '401':
 *         description: Não autorizado
 * /cobrancas/{id}:
 *   put:
 *     summary: Atualiza os dados de uma cobrança
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
 *             $ref: '#/components/schemas/Cobranca'
 *     responses:
 *       '200':
 *         description: Cobrança atualizada com sucesso
 *       '400':
 *         description: Dados de entrada inválidos
 *       '404':
 *         description: Cobrança não encontrada
 *   delete:
 *     summary: Remove uma cobrança
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *     responses:
 *       '204':
 *         description: Cobrança removida com sucesso
 *       '404':
 *         description: Cobrança não encontrada
 */
