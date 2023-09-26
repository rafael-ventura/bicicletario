// ... (Outros imports e configurações Swagger)

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
 *           type: integer
 *         required: true
 *         description: ID do totem.
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Totem'
 *           example:
 *             status: "Inativo"
 *     responses:
 *       200:
 *         description: Totem atualizado com sucesso
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Totem'
 *       400:
 *         description: Dados de entrada inválidos
 *         content:
 *           application/json:
 *             example:
 *               error: "Informações do totem estão incompletas ou inválidas"
 *       404:
 *         description: Totem não encontrado
 *         content:
 *           application/json:
 *             example:
 *               error: "Totem não encontrado"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível atualizar o totem"
 *
 *   delete:
 *     summary: Remove um totem da rede
 *     tags: [Totem]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID do totem.
 *     responses:
 *       204:
 *         description: Totem removido com sucesso
 *       404:
 *         description: Totem não encontrado
 *         content:
 *           application/json:
 *             example:
 *               error: "Totem não encontrado"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível remover o totem"
 */
