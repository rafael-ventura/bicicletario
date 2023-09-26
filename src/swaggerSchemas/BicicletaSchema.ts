/**
 * @swagger
 * components:
 *   schemas:
 *     Bicicleta:
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
 * /bicicletas:
 *   post:
 *     summary: Adiciona uma nova bicicleta
 *     tags: [Bicicleta]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Bicicleta'
 *     responses:
 *       201:
 *         description: Bicicleta adicionada com sucesso
 *       400:
 *         description: Dados de entrada inválidos
 *   get:
 *     summary: Lista todas as bicicletas
 *     tags: [Bicicleta]
 *     responses:
 *       200:
 *         description: Lista de bicicletas
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Bicicleta'
 *       404:
 *         description: Nenhuma bicicleta encontrada
 */

/**
 * @swagger
 * /bicicletas/{id}:
 *   put:
 *     summary: Atualiza o status de uma bicicleta
 *     tags: [Bicicleta]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID da bicicleta.
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Bicicleta'
 *     responses:
 *       200:
 *         description: Bicicleta atualizada com sucesso
 *       404:
 *         description: Bicicleta não encontrada
 *   delete:
 *     summary: Remove uma bicicleta da rede
 *     tags: [Bicicleta]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID da bicicleta.
 *     responses:
 *       204:
 *         description: Bicicleta removida com sucesso
 *       404:
 *         description: Bicicleta não encontrada
 */
