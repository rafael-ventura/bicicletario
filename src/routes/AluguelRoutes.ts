/**
 * @swagger
 * tags:
 *   name: Alugueis
 *   description: Microserviço de Aluguéis de Bicicletas.
 */

/**
 * @swagger
 * /alugueis:
 *   get:
 *     summary: Visualizar todos os aluguéis.
 *     tags: [Alugueis]
 *     responses:
 *       200:
 *         description: Lista de aluguéis.
 *
 * /alugueis/{idUsuario}:
 *   get:
 *     summary: Visualizar aluguéis de um usuário específico.
 *     tags: [Alugueis]
 *     parameters:
 *       - in: path
 *         name
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID do usuário.
 *     responses:
 *       200:
 *         description: Lista de aluguéis do usuário.
 */