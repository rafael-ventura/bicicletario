/*import { Request, Response } from 'express';*/
// ... (Outros imports necessários)

/**
 * @swagger
 * /notificacoes/{id}:
 *   put:
 *     summary: Atualiza o status de uma notificação
 *     tags: [Notificacao]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID da notificação.
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Notificacao'
 *           example:
 *             status: "lida"
 *     responses:
 *       200:
 *         description: Notificação atualizada com sucesso
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Notificacao'
 *       400:
 *         description: Dados de entrada inválidos
 *         content:
 *           application/json:
 *             example:
 *               error: "Informações da notificação estão incompletas ou inválidas"
 *       404:
 *         description: Notificação não encontrada
 *         content:
 *           application/json:
 *             example:
 *               error: "Notificação não encontrada"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível atualizar a notificação"
 */
/*
async function updateStatus(req: NotificacaoRequest, res: Response) {
  // Implementação será feita depois
}
*/

/**
 * @swagger
 * /notificacoes/{id}:
 *   delete:
 *     summary: Remove uma notificação
 *     tags: [Notificacao]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID da notificação.
 *     responses:
 *       204:
 *         description: Notificação removida com sucesso
 *       404:
 *         description: Notificação não encontrada
 *         content:
 *           application/json:
 *             example:
 *               error: "Notificação não encontrada"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível remover a notificação"
 */
/*
async function remove(req: Request, res: Response) {
  // Implementação será feita depois
}
*/

/*
export default {
  send,
  listAll,
  // updateStatus,
  // remove,
} as const;
*/
