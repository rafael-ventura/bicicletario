/**
 * @swagger
 * /cobrancas:
 *   post:
 *     summary: Registra uma nova cobrança
 *     tags: [Cobranca]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Cobranca'
 *           example:
 *             idLocatario: "1"
 *             valor: 100.50
 *             data: "2023-10-01"
 *             hora: "12:30"
 *             detalhes: "Cobrança de aluguel de bicicleta"
 *     responses:
 *       201:
 *         description: Cobrança registrada com sucesso
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Cobranca'
 *       400:
 *         description: Dados de entrada inválidos
 *         content:
 *           application/json:
 *             example:
 *               error: "Dados de entrada inválidos"
 */
/*async function create(req: CobrancaRequest, res: Response) {
  const { cobranca } = req.body;
  /!*const newCobranca = await CobrancaService.create(cobranca);*!/
  return res.status(HttpStatusCodes.CREATED);
}*/

/**
 * @swagger
 * /cobrancas:
 *   get:
 *     summary: Lista todas as cobranças
 *     tags: [Cobranca]
 *     responses:
 *       200:
 *         description: Lista de cobranças
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Cobranca'
 *       401:
 *         description: Não autorizado
 *         content:
 *           application/json:
 *             example:
 *               error: "Não autorizado"
 */
/*async function listAll(req: Request, res: Response) {
  /!*const cobrancas = await CobrancaService.listAll();*!/
  return res.status(HttpStatusCodes.OK);
}*/

/**
 * @swagger
 * /cobrancas/{id}:
 *   put:
 *     summary: Atualiza os dados de uma cobrança
 *     tags: [Cobranca]
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
 *           example:
 *             valor: 150.75
 *     responses:
 *       200:
 *         description: Cobrança atualizada com sucesso
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Cobranca'
 *       400:
 *         description: Dados de entrada inválidos
 *         content:
 *           application/json:
 *             example:
 *               error: "Dados de entrada inválidos"
 *       404:
 *         description: Cobrança não encontrada
 *         content:
 *           application/json:
 *             example:
 *               error: "Cobrança não encontrada"
 */

/*
async function update(req: CobrancaRequest, res: Response) {
  /!*const { id } = req.params;
  const { cobranca } = req.body;
  const updatedCobranca = await CobrancaService.update(id, cobranca);*!/
  return res.status(HttpStatusCodes.OK);
}
*/

/**
 * @swagger
 * /cobrancas/{id}:
 *   delete:
 *     summary: Remove uma cobrança
 *     tags: [Cobranca]
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *         description: ID da cobrança
 *     responses:
 *       204:
 *         description: Cobrança removida com sucesso
 *       404:
 *         description: Cobrança não encontrada
 *         content:
 *           application/json:
 *             example:
 *               error: "Cobrança não encontrada"
 *       500:
 *         description: Erro interno do servidor
 *         content:
 *           application/json:
 *             example:
 *               error: "Não foi possível remover a cobrança"
 */





