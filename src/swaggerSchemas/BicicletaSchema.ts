// ... (Outros imports e configurações Swagger)

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
 *           type: integer
 *         required: true
 *         description: ID da bicicleta.
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Bicicleta'
 *           example:
 *             status: "Manutenção"
 *     responses:
 *       200:
 *         description: Bicicleta atualizada com sucesso
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Bicicleta'
 *       400:
 *         description: Dados de entrada inválidos
 *         content:
 *           application/json:
 *             example:
 *               error: "Informações da bicicleta estão incompletas ou inválidas"
 *       404:
 *         description: Bicicleta não encontrada
 *         content:
 *           application/json:
 *             example:
 *               error: "Bicicleta não encontrada"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível atualizar a bicicleta"
 *
 *   delete:
 *     summary: Remove uma bicicleta da rede
 *     tags: [Bicicleta]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID da bicicleta.
 *     responses:
 *       204:
 *         description: Bicicleta removida com sucesso
 *       404:
 *         description: Bicicleta não encontrada
 *         content:
 *           application/json:
 *             example:
 *               error: "Bicicleta não encontrada"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível remover a bicicleta"
 */
