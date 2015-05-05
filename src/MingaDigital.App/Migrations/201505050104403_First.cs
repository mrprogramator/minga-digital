namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.accion",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.actividad",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(nullable: false),
                        descripcion = c.String(),
                        tiempo_inicio = c.DateTimeOffset(nullable: false, precision: 7),
                        tiempo_fin = c.DateTimeOffset(nullable: false, precision: 7),
                        realizado = c.Boolean(nullable: false),
                        tipo_actividad_id = c.Int(nullable: false),
                        usuario_creador_id = c.Int(nullable: false),
                        persona_encargada_id = c.Int(nullable: false),
                        unidad_educativa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.persona_fisica", t => t.persona_encargada_id, cascadeDelete: true)
                .ForeignKey("public.tipo_actividad", t => t.tipo_actividad_id, cascadeDelete: true)
                .ForeignKey("public.unidad_educativa", t => t.unidad_educativa_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_creador_id, cascadeDelete: true)
                .Index(t => t.tipo_actividad_id)
                .Index(t => t.usuario_creador_id)
                .Index(t => t.persona_encargada_id)
                .Index(t => t.unidad_educativa_id);
            
            CreateTable(
                "public.persona_fisica",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombres = c.String(),
                        apellidos = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.tipo_actividad",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.unidad_educativa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ubicacion_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.ubicacion", t => t.ubicacion_id, cascadeDelete: true)
                .Index(t => t.ubicacion_id);
            
            CreateTable(
                "public.ubicacion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        municipio_id = c.Int(nullable: false),
                        distrito = c.Int(nullable: false),
                        unidad_vecinal = c.Int(nullable: false),
                        direccion = c.String(),
                        geo_coordenada_latitud = c.Decimal(nullable: false, precision: 18, scale: 2),
                        geo_coordenada_longitud = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.municipio", t => t.municipio_id, cascadeDelete: true)
                .Index(t => t.municipio_id);
            
            CreateTable(
                "public.municipio",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password_hash = c.Binary(nullable: false),
                        password_salt = c.Binary(nullable: false),
                        password_algorithm = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.username, unique: true);
            
            CreateTable(
                "public.permiso_global",
                c => new
                    {
                        accion_id = c.String(nullable: false, maxLength: 128),
                        usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.accion_id, t.usuario_id })
                .ForeignKey("public.accion", t => t.accion_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.accion_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "public.rol",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "public.activo_minga",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        establecimiento_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.establecimiento_minga", t => t.establecimiento_id, cascadeDelete: true)
                .Index(t => t.establecimiento_id);
            
            CreateTable(
                "public.establecimiento_minga",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ubicacion_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.ubicacion", t => t.ubicacion_id, cascadeDelete: true)
                .Index(t => t.ubicacion_id);
            
            CreateTable(
                "public.persona_juridica",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.area_incidencia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.item_movimiento",
                c => new
                    {
                        movimiento_id = c.Int(nullable: false),
                        activo_minga_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.movimiento_id, t.activo_minga_id })
                .ForeignKey("public.activo_minga", t => t.activo_minga_id, cascadeDelete: true)
                .ForeignKey("public.movimiento", t => t.movimiento_id, cascadeDelete: true)
                .Index(t => t.movimiento_id)
                .Index(t => t.activo_minga_id);
            
            CreateTable(
                "public.movimiento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        origen_id = c.Int(nullable: false),
                        destino_id = c.Int(nullable: false),
                        fecha_hora = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.establecimiento_minga", t => t.destino_id, cascadeDelete: true)
                .ForeignKey("public.establecimiento_minga", t => t.origen_id, cascadeDelete: true)
                .Index(t => t.origen_id)
                .Index(t => t.destino_id);
            
            CreateTable(
                "public.permiso_rol",
                c => new
                    {
                        accion_id = c.String(nullable: false, maxLength: 128),
                        rol_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.accion_id, t.rol_id })
                .ForeignKey("public.accion", t => t.accion_id, cascadeDelete: true)
                .ForeignKey("public.rol", t => t.rol_id, cascadeDelete: true)
                .Index(t => t.accion_id)
                .Index(t => t.rol_id);
            
            CreateTable(
                "public.ticket",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false),
                        prioridad = c.Int(nullable: false),
                        estado_ticket = c.Int(nullable: false),
                        fecha_hora_creado = c.DateTimeOffset(nullable: false, precision: 7),
                        fecha_hora_atendido = c.DateTimeOffset(precision: 7),
                        fecha_hora_cerrado = c.DateTimeOffset(precision: 7),
                        tipo_incidencia_id = c.Int(nullable: false),
                        telecentro_id = c.Int(nullable: false),
                        usuario_id = c.Int(nullable: false),
                        encargado_id = c.Int(),
                        Equipo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.usuario", t => t.encargado_id)
                .ForeignKey("public.equipo", t => t.Equipo_Id)
                .ForeignKey("public.telecentro", t => t.telecentro_id)
                .ForeignKey("public.tipo_incidencia", t => t.tipo_incidencia_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.tipo_incidencia_id)
                .Index(t => t.telecentro_id)
                .Index(t => t.usuario_id)
                .Index(t => t.encargado_id)
                .Index(t => t.Equipo_Id);
            
            CreateTable(
                "public.tipo_incidencia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        area_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.area_incidencia", t => t.area_id, cascadeDelete: true)
                .Index(t => t.area_id);
            
            CreateTable(
                "public.usuario_rol",
                c => new
                    {
                        usuario_id = c.Int(nullable: false),
                        rol_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.usuario_id, t.rol_id })
                .ForeignKey("public.rol", t => t.rol_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.usuario_id)
                .Index(t => t.rol_id);
            
            CreateTable(
                "public.almacen",
                c => new
                    {
                        id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.establecimiento_minga", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "public.componente",
                c => new
                    {
                        id = c.Int(nullable: false),
                        tipo = c.Int(nullable: false),
                        marca = c.String(),
                        caracteristica = c.String(),
                        equipo_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.activo_minga", t => t.id)
                .ForeignKey("public.equipo", t => t.equipo_id)
                .Index(t => t.id)
                .Index(t => t.equipo_id);
            
            CreateTable(
                "public.equipo",
                c => new
                    {
                        id = c.Int(nullable: false),
                        detalle = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.activo_minga", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "public.telecentro",
                c => new
                    {
                        id = c.Int(nullable: false),
                        estado_id = c.Int(nullable: false),
                        patrocinador_id = c.Int(nullable: false),
                        estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.establecimiento_minga", t => t.id)
                .ForeignKey("public.persona_juridica", t => t.patrocinador_id, cascadeDelete: true)
                .Index(t => t.id)
                .Index(t => t.patrocinador_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.telecentro", "patrocinador_id", "public.persona_juridica");
            DropForeignKey("public.telecentro", "id", "public.establecimiento_minga");
            DropForeignKey("public.equipo", "id", "public.activo_minga");
            DropForeignKey("public.componente", "equipo_id", "public.equipo");
            DropForeignKey("public.componente", "id", "public.activo_minga");
            DropForeignKey("public.almacen", "id", "public.establecimiento_minga");
            DropForeignKey("public.usuario_rol", "usuario_id", "public.usuario");
            DropForeignKey("public.usuario_rol", "rol_id", "public.rol");
            DropForeignKey("public.ticket", "usuario_id", "public.usuario");
            DropForeignKey("public.ticket", "tipo_incidencia_id", "public.tipo_incidencia");
            DropForeignKey("public.tipo_incidencia", "area_id", "public.area_incidencia");
            DropForeignKey("public.ticket", "telecentro_id", "public.telecentro");
            DropForeignKey("public.ticket", "Equipo_Id", "public.equipo");
            DropForeignKey("public.ticket", "encargado_id", "public.usuario");
            DropForeignKey("public.permiso_rol", "rol_id", "public.rol");
            DropForeignKey("public.permiso_rol", "accion_id", "public.accion");
            DropForeignKey("public.item_movimiento", "movimiento_id", "public.movimiento");
            DropForeignKey("public.movimiento", "origen_id", "public.establecimiento_minga");
            DropForeignKey("public.movimiento", "destino_id", "public.establecimiento_minga");
            DropForeignKey("public.item_movimiento", "activo_minga_id", "public.activo_minga");
            DropForeignKey("public.activo_minga", "establecimiento_id", "public.establecimiento_minga");
            DropForeignKey("public.establecimiento_minga", "ubicacion_id", "public.ubicacion");
            DropForeignKey("public.actividad", "usuario_creador_id", "public.usuario");
            DropForeignKey("public.rol", "Usuario_Id", "public.usuario");
            DropForeignKey("public.permiso_global", "usuario_id", "public.usuario");
            DropForeignKey("public.permiso_global", "accion_id", "public.accion");
            DropForeignKey("public.actividad", "unidad_educativa_id", "public.unidad_educativa");
            DropForeignKey("public.unidad_educativa", "ubicacion_id", "public.ubicacion");
            DropForeignKey("public.ubicacion", "municipio_id", "public.municipio");
            DropForeignKey("public.actividad", "tipo_actividad_id", "public.tipo_actividad");
            DropForeignKey("public.actividad", "persona_encargada_id", "public.persona_fisica");
            DropIndex("public.telecentro", new[] { "patrocinador_id" });
            DropIndex("public.telecentro", new[] { "id" });
            DropIndex("public.equipo", new[] { "id" });
            DropIndex("public.componente", new[] { "equipo_id" });
            DropIndex("public.componente", new[] { "id" });
            DropIndex("public.almacen", new[] { "id" });
            DropIndex("public.usuario_rol", new[] { "rol_id" });
            DropIndex("public.usuario_rol", new[] { "usuario_id" });
            DropIndex("public.tipo_incidencia", new[] { "area_id" });
            DropIndex("public.ticket", new[] { "Equipo_Id" });
            DropIndex("public.ticket", new[] { "encargado_id" });
            DropIndex("public.ticket", new[] { "usuario_id" });
            DropIndex("public.ticket", new[] { "telecentro_id" });
            DropIndex("public.ticket", new[] { "tipo_incidencia_id" });
            DropIndex("public.permiso_rol", new[] { "rol_id" });
            DropIndex("public.permiso_rol", new[] { "accion_id" });
            DropIndex("public.movimiento", new[] { "destino_id" });
            DropIndex("public.movimiento", new[] { "origen_id" });
            DropIndex("public.item_movimiento", new[] { "activo_minga_id" });
            DropIndex("public.item_movimiento", new[] { "movimiento_id" });
            DropIndex("public.establecimiento_minga", new[] { "ubicacion_id" });
            DropIndex("public.activo_minga", new[] { "establecimiento_id" });
            DropIndex("public.rol", new[] { "Usuario_Id" });
            DropIndex("public.permiso_global", new[] { "usuario_id" });
            DropIndex("public.permiso_global", new[] { "accion_id" });
            DropIndex("public.usuario", new[] { "username" });
            DropIndex("public.ubicacion", new[] { "municipio_id" });
            DropIndex("public.unidad_educativa", new[] { "ubicacion_id" });
            DropIndex("public.actividad", new[] { "unidad_educativa_id" });
            DropIndex("public.actividad", new[] { "persona_encargada_id" });
            DropIndex("public.actividad", new[] { "usuario_creador_id" });
            DropIndex("public.actividad", new[] { "tipo_actividad_id" });
            DropTable("public.telecentro");
            DropTable("public.equipo");
            DropTable("public.componente");
            DropTable("public.almacen");
            DropTable("public.usuario_rol");
            DropTable("public.tipo_incidencia");
            DropTable("public.ticket");
            DropTable("public.permiso_rol");
            DropTable("public.movimiento");
            DropTable("public.item_movimiento");
            DropTable("public.area_incidencia");
            DropTable("public.persona_juridica");
            DropTable("public.establecimiento_minga");
            DropTable("public.activo_minga");
            DropTable("public.rol");
            DropTable("public.permiso_global");
            DropTable("public.usuario");
            DropTable("public.municipio");
            DropTable("public.ubicacion");
            DropTable("public.unidad_educativa");
            DropTable("public.tipo_actividad");
            DropTable("public.persona_fisica");
            DropTable("public.actividad");
            DropTable("public.accion");
        }
    }
}
