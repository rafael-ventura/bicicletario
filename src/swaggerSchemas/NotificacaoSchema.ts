/**
 * @swagger
 * components:
 *   schemas:
 *     Notificacao:
 *       type: object
 *       required:
 *         - id
 *         - usuarioId
 *         - mensagem
 *         - dataHora
 *         - status
 *       properties:
 *         id:
 *           type: string
 *         usuarioId:
 *           type: string
 *         mensagem:
 *           type: string
 *         dataHora:
 *           type: string
 *           format: date-time
 *         status:
 *           type: string
 *           enum: [Nao Lida, Lida]
 */

// TODO: Colocar as rotas/Endpoints aqui