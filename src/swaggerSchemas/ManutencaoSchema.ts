/**
 * @swagger
 * components:
 *   schemas:
 *     Manutencao:
 *       type: object
 *       required:
 *         - id
 *         - tipo
 *         - itemId
 *         - descricao
 *         - dataInicio
 *         - status
 *       properties:
 *         id:
 *           type: string
 *         tipo:
 *           type: string
 *           enum: [Bicicleta, Tranca]
 *         itemId:
 *           type: string
 *         descricao:
 *           type: string
 *         dataInicio:
 *           type: string
 *           format: date-time
 *         dataFim:
 *           type: string
 *           format: date-time
 *         status:
 *           type: string
 *           enum: [Pendente, Em Andamento, Concluida]
 */

// TODO: Colocar as rotas/Endpoints aqui
