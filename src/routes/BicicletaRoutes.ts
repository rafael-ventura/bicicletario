/**
 * @swagger
 * tags:
 *   name: Bicicletas
 *   description: Microserviço de Bicicletas.
 */

/**
 * @swagger
 * /bicicletas:
 *   get:
 *     summary: Lista todas as bicicletas
 *     description: Retorna uma lista de todas as bicicletas registradas no sistema.
 *     tags:
 *       - Bicicleta
 *     parameters:
 *       - in: query
 *         name: marca
 *         schema:
 *           type: string
 *         description: Filtra bicicletas pela marca.
 *     responses:
 *       200:
 *         description: Lista de bicicletas.
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 $ref: '#/components/schemas/Bicicleta'
 *             example:
 *               - id: 1
 *                 marca: Caloi
 *                 modelo: Elite
 *                 localizacao: São Paulo
 *               - id: 2
 *                 marca: Monark
 *                 modelo: Mountain Bike
 *                 localizacao: Rio de Janeiro
 *       404:
 *         description: Nenhuma bicicleta encontrada.
 *         content:
 *           application/json:
 *             example:
 *               error: Não existem bicicletas registradas com a marca fornecida.
 */


/**
 * @swagger
 * /bicicletas:
 *   post:
 *     summary: Adiciona uma nova bicicleta
 *     description: Registra uma nova bicicleta no sistema.
 *     tags:
 *       - Bicicleta
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/Bicicleta'
 *           example:
 *             marca: Caloi
 *             modelo: Elite
 *             localizacao: São Paulo
 *     responses:
 *       201:
 *         description: Bicicleta adicionada com sucesso.
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Bicicleta'
 *             example:
 *               id: 1
 *               marca: Caloi
 *               modelo: Elite
 *               localizacao: São Paulo
 *       400:
 *         description: Dados inválidos fornecidos.
 *         content:
 *           application/json:
 *             example:
 *               error: Dados da bicicleta estão incompletos ou inválidos.
 */

/**
 * /bicicletas/{idBicicleta}:
 *   delete:
 *     summary: Remover uma bicicleta.
 *     tags: [Bicicletas]
 *     parameters:
 *       - in: path
 *         name: idBicicleta
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID da bicicleta.
 *     responses:
 *       200:
 *         description: Bicicleta removida com sucesso.
 *
 */

/**
 * /bicicletas/{idBicicleta}/alugar:
 *   post:
 *     summary: Alugar uma bicicleta.
 *     tags: [Bicicletas]
 *     parameters:
 *       - in: path
 *         name: idBicicleta
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID da bicicleta.
 *     responses:
 *       200:
 *         description: Bicicleta alugada com sucesso.
 */

/**
 * /bicicletas/{idBicicleta}/devolver:
 *   post:
 *     summary: Devolver uma bicicleta alugada.
 *     tags: [Bicicletas]
 *     parameters:
 *       - in: path
 *         name: idBicicleta
 *         schema:
 *           type: integer
 *         required: true
 *         description: ID da bicicleta.
 *     responses:
 *       200:
 *         description: Bicicleta devolvida com sucesso.
 */

