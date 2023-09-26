/**
 * @swagger
 * components:
 *   schemas:
 *     Bicicleta:
 *       type: object
 *       required:
 *         - id
 *         - marca
 *         - modelo
 *         - anoAquisicao
 *         - status
 *         - localizacaoAtual
 *       properties:
 *         id:
 *           type: string
 *         marca:
 *           type: string
 *         modelo:
 *           type: string
 *         anoAquisicao:
 *           type: integer
 *         status:
 *           type: string
 *           enum: [Disponível, Em Manutenção]
 *         localizacaoAtual:
 *           $ref: '#/components/schemas/Localizacao'
 */

// TODO: Colocar as rotas/Endpoints aqui
