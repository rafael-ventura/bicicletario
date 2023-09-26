/*import { Request, Response } from 'express';*/
// ... (Outros imports necessários)

/**
 * @swagger
 * /manutencoes/{id}:
 *   put:
 *     summary: Atualiza o status de uma manutenção
 *     tags: [Manutencao]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID da manutenção.
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Manutencao'
 *           example:
 *             status: "concluida"
 *     responses:
 *       200:
 *         description: Manutenção atualizada com sucesso
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Manutencao'
 *       400:
 *         description: Dados de entrada inválidos
 *         content:
 *           application/json:
 *             example:
 *               error: "Informações da manutenção estão incompletas ou inválidas"
 *       404:
 *         description: Manutenção não encontrada
 *         content:
 *           application/json:
 *             example:
 *               error: "Manutenção não encontrada"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível atualizar a manutenção"
 */
/*
async function updateStatus(req: ManutencaoRequest, res: Response) {
  // Implementação será feita depois
}
*/

/**
 * @swagger
 * /manutencoes/{id}:
 *   delete:
 *     summary: Conclui uma manutenção
 *     tags: [Manutencao]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID da manutenção.
 *     responses:
 *       204:
 *         description: Manutenção concluída com sucesso
 *       404:
 *         description: Manutenção não encontrada
 *         content:
 *           application/json:
 *             example:
 *               error: "Manutenção não encontrada"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível concluir a manutenção"
 */
/*
async function conclude(req: Request, res: Response) {
  // Implementação será feita depois
}
*/

/*
export default {
  register,
  listAll,
  // updateStatus,
  // conclude,
} as const;
*/
