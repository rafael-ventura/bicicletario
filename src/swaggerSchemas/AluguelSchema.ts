/**
 * @swagger
 * components:
 *   schemas:
 *     Aluguel:
 *       type: object
 *       required:
 *         - id
 *         - usuarioId
 *         - bicicletaId
 *         - dataHoraRetirada
 *         - localizacaoRetirada
 *         - status
 *       properties:
 *         id:
 *           type: string
 *         usuarioId:
 *           type: string
 *         bicicletaId:
 *           type: string
 *         dataHoraRetirada:
 *           type: string
 *           format: date-time
 *         dataHoraDevolucao:
 *           type: string
 *           format: date-time
 *         localizacaoRetirada:
 *           $ref: '#/components/schemas/Localizacao'
 *         localizacaoDevolucao:
 *           $ref: '#/components/schemas/Localizacao'
 *         status:
 *           type: string
 *           enum: [Em Andamento, Concluído]
 *         valorCobrado:
 *           type: number
 */

// TODO: Colocar as rotas/Endpoints aqui
