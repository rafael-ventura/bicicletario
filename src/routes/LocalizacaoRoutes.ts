/**
 * @swagger
 * /localizacoes:
 *   post:
 *     summary: Cria uma nova localização
 *     tags: [Localizacao]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Localizacao'
 *     responses:
 *       201:
 *         description: Localização criada com sucesso
 *       400:
 *         description: Dados de entrada inválidos
 */
// Método para criar uma nova localização


/**
 * @swagger
 * /localizacoes/{id}:
 *   get:
 *     summary: Obtém detalhes de uma localização específica
 *     tags: [Localizacao]
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *     responses:
 *       200:
 *         description: Detalhes da localização
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Localizacao'
 *       404:
 *         description: Localização não encontrada
 */
// Método para obter detalhes de uma localização


/**
 * @swagger
 * /localizacoes/{id}:
 *   put:
 *     summary: Atualiza uma localização específica
 *     tags: [Localizacao]
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
 *             $ref: '#/components/schemas/Localizacao'
 *     responses:
 *       200:
 *         description: Localização atualizada com sucesso
 *       400:
 *         description: Dados de entrada inválidos
 *       404:
 *         description: Localização não encontrada
 */
// Método para atualizar uma localização


/**
 * @swagger
 * /localizacoes/{id}:
 *   delete:
 *     summary: Remove uma localização específica
 *     tags: [Localizacao]
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *     responses:
 *       204:
 *         description: Localização removida com sucesso
 *       404:
 *         description: Localização não encontrada
 */
// Método para remover uma localização
