using IsenClases.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace IsenClases.Repositories
{
    public class SqlServerRepository : IDbRepository
    {
        DbContext ctx;

        public SqlServerRepository()
        {
        }

        public void Inicializar() 
        {
            using (var con = new isenEntities())
            {
                int numAlumnos = con.Database.SqlQuery<int>("SELECT COUNT(*) FROM ALUMNOS").FirstOrDefault();

                if (numAlumnos == 0)
                {
                    con.Database.ExecuteSqlCommand("INSERT INTO ALUMNOS (DNI, NOMBRE, APELLIDOS, PASSWORD) VALUES ('22123123X', 'JESÚS', 'GÓMEZ SÁNCHEZ', '1234')");
                    con.Database.ExecuteSqlCommand("INSERT INTO ALUMNOS (DNI, NOMBRE, APELLIDOS, PASSWORD) VALUES ('22456123Q', 'ANA', 'SÁNCHEZ GARCÍA', '5678')");
                    con.Database.ExecuteSqlCommand("INSERT INTO ALUMNOS (DNI, NOMBRE, APELLIDOS, PASSWORD) VALUES ('22789456W', 'LAURA', 'GARCÍA ALBALADEJO', '9876')");
                    con.Database.ExecuteSqlCommand("INSERT INTO ALUMNOS (DNI, NOMBRE, APELLIDOS, PASSWORD) VALUES ('22123789P', 'ANTONIO', 'GÓMEZ FULGENCIO', '5432')");
                    con.Database.ExecuteSqlCommand("INSERT INTO ALUMNOS (DNI, NOMBRE, APELLIDOS, PASSWORD) VALUES ('22369258S', 'ALICIA', 'LARA ALVAREZ', '1478')");
                }

                int numProfesores = con.Database.SqlQuery<int>("SELECT COUNT(*) FROM PROFESORES").FirstOrDefault();

                if (numProfesores == 0)
                {
                    con.Database.ExecuteSqlCommand("INSERT INTO PROFESORES (DNI, NOMBRE, APELLIDOS, PASSWORD) VALUES ('22123222L', 'JESÚS', 'GÓMEZ SÁNCHEZ', '1234')");
                    con.Database.ExecuteSqlCommand("INSERT INTO PROFESORES (DNI, NOMBRE, APELLIDOS, PASSWORD) VALUES ('21456333M', 'ANA', 'GARCÍA PERALES', '5678')");
                    con.Database.ExecuteSqlCommand("INSERT INTO PROFESORES (DNI, NOMBRE, APELLIDOS, PASSWORD) VALUES ('21789444N', 'JUAN', 'MADRID PEREZ', '9876')");
                }

                int numAsignaturas = con.Database.SqlQuery<int>("SELECT COUNT(*) FROM ASIGNATURAS").FirstOrDefault();

                if (numAsignaturas == 0)
                {
                    con.Database.ExecuteSqlCommand("INSERT INTO ASIGNATURAS (TITULO, DESCRIPCION, ID_PROFESOR) VALUES ('ASIGNATURA 1', '', 1)");
                    con.Database.ExecuteSqlCommand("INSERT INTO ASIGNATURAS (TITULO, DESCRIPCION, ID_PROFESOR) VALUES ('ASIGNATURA 2', 'LOREM IPSUM', 2)");
                    con.Database.ExecuteSqlCommand("INSERT INTO ASIGNATURAS (TITULO, DESCRIPCION, ID_PROFESOR) VALUES ('ASIGNATURA 3', 'ABCD', 1)");
                }

                int numMatriculas = con.Database.SqlQuery<int>("SELECT COUNT(*) FROM MATRICULA").FirstOrDefault();

                if (numMatriculas == 0)
                {
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (1, 1, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (2, 1, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (3, 1, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (4, 1, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (5, 1, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (1, 2, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (2, 3, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (3, 2, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (4, 2, GETDATE())");
                    con.Database.ExecuteSqlCommand("INSERT INTO MATRICULA (ID_ALUMNO, ID_ASIGNATURA, FECHA_MATRICULA) VALUES (3, 3, GETDATE())");
                }

                int numClases = con.Database.SqlQuery<int>("SELECT COUNT(*) FROM CLASES").FirstOrDefault();

                if (numClases == 0)
                {
                    con.Database.ExecuteSqlCommand("INSERT INTO CLASES (FECHA, HORA, ID_ASIGNATURA) VALUES (cast('08/06/2020' as date), '11:00', 1)");
                    con.Database.ExecuteSqlCommand("INSERT INTO CLASES (FECHA, HORA, ID_ASIGNATURA) VALUES (cast('18/06/2020' as date), '12:00', 2)");
                    con.Database.ExecuteSqlCommand("INSERT INTO CLASES (FECHA, HORA, ID_ASIGNATURA) VALUES (cast('28/06/2020' as date), '17:30', 3)");
                    con.Database.ExecuteSqlCommand("INSERT INTO CLASES (FECHA, HORA, ID_ASIGNATURA) VALUES (cast('10/06/2020' as date), '10:10', 1)");
                    con.Database.ExecuteSqlCommand("INSERT INTO CLASES (FECHA, HORA, ID_ASIGNATURA) VALUES (cast('11/06/2020' as date), '13:30', 2)");
                    con.Database.ExecuteSqlCommand("INSERT INTO CLASES (FECHA, HORA, ID_ASIGNATURA) VALUES (cast('12/06/2020' as date), '15:45', 3)");
                }
            }
        }

        public IEnumerable<IUsuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public IUsuario GetUsuario(string dni) 
        {
            using (var con = new isenEntities())
            {
                ALUMNOS alumnoDB = con.Database.SqlQuery<ALUMNOS>("Select * from ALUMNOS where DNI=@id", new SqlParameter("@id", dni))
                                 .FirstOrDefault();

                if (alumnoDB != null) return new Alumno(alumnoDB);

                PROFESORES profesorDB = con.Database.SqlQuery<PROFESORES>("Select * from PROFESORES where DNI=@id", new SqlParameter("@id", dni))
                                 .FirstOrDefault();

                if (profesorDB != null) return new Profesor(profesorDB);

                return null;
            }
        }

        public List<Clases> GetClases(IUsuario usuario) 
        {
            List<Clases> clases = new List<Clases>();
            
            using (var con = new isenEntities()) 
            {
                if ("P".Equals(usuario.Rol))
                {
                    List<CLASES> cList = con.Database.SqlQuery<CLASES>("Select c.* from clases c inner join asignaturas a on c.id_asignatura = a.id where a.id_profesor = @idUsuario", new SqlParameter("@idUsuario", usuario.IdUsuario)).ToList();
                    foreach (CLASES c in cList)
                    {
                        Clases cls = new Clases(c);

                        cls.ListaAlumnos = con.Database.SqlQuery<Alumno>("Select A.* from ALUMNOS A INNER JOIN REGISTROS R ON A.ID = R.ID_ALUMNO INNER JOIN CLASES C ON R.ID_CLASE = C.ID where C.ID = @idClase", new SqlParameter("@idClase", c.ID)).ToList();
                        clases.Add(cls);
                    }
                }
                else 
                {
                    List<CLASES> cList = con.Database.SqlQuery<CLASES>("SELECT C.* FROM CLASES C INNER JOIN MATRICULA M ON C.ID_ASIGNATURA = M.ID_ASIGNATURA WHERE M.ID_ALUMNO = @idAlumno", new SqlParameter("@idAlumno", usuario.IdUsuario)).ToList();
                    foreach (CLASES c in cList) 
                    {
                        Clases cls = new Clases(c);
                        cls.Asignatura = new Asignatura(con.ASIGNATURAS.Find(c.ID_ASIGNATURA)); 
                        clases.Add(cls);
                    }
                    List<REGISTROS> registrosBD = con.REGISTROS.Where(x => x.ID_ALUMNO == usuario.IdUsuario).ToList();
                    List<Registro> registros = new List<Registro>();
                    foreach (REGISTROS r in registrosBD) 
                    {
                        Registro rg = new Registro()
                        {
                            AlumnoObj = new Alumno(con.ALUMNOS.Find(r.ID_ALUMNO)),
                            ClaseObj = new Clases(con.CLASES.Find(r.CLASES)),
                            Asistencia = r.ASISTE.Value
                        };
                        registros.Add(rg);
                    }
                    ((Alumno)usuario).ClasesApuntadas = registros;
                }
            }

            return clases;
        }

        public void GetAsignaturas(IUsuario usuario)
        {
            if ("E".Equals(usuario.Rol))
            {
                using (var con = new isenEntities())
                {
                    List<ASIGNATURAS> cList = con.Database.SqlQuery<ASIGNATURAS>("SELECT A.* FROM ASIGNATURAS A INNER JOIN MATRICULA M ON A.ID = M.ID_ASIGNATURA WHERE M.ID_ALUMNO = @idAlumno", new SqlParameter("@idAlumno", usuario.IdUsuario)).ToList();
                    foreach (ASIGNATURAS a in cList)
                    {
                        Asignatura asg = new Asignatura(a);
                        if (a.ID_PROFESOR.HasValue)
                        {
                            PROFESORES pBD = con.PROFESORES.Find(a.ID_PROFESOR.Value);
                            Profesor p = new Profesor(pBD);
                            asg.Profesor = p;
                        }
                        usuario.ListaAsignaturas.Add(asg);
                    }
                }
            }
            else if (("P").Equals(usuario.Rol)) 
            {
                using (var con = new isenEntities())
                {
                    List<ASIGNATURAS> cList = con.ASIGNATURAS.Where(x => x.ID_PROFESOR.HasValue && x.ID_PROFESOR.Value == usuario.IdUsuario).ToList();
                    foreach (ASIGNATURAS aBD in cList) 
                    {
                        Asignatura asg = new Asignatura(aBD);
                        usuario.ListaAsignaturas.Add(asg);
                    }
                }
            }
        }

        public bool IsProfesorAsignatura(int idClase, int idUsuario)
        {
            using (var con = new isenEntities()) 
            {
                ASIGNATURAS asignatura = con.ASIGNATURAS.Find(con.CLASES.Find(idClase).ID_ASIGNATURA);

                if (asignatura != null) 
                {
                    return asignatura.ID_PROFESOR == idUsuario;
                }
            }

            return false;
        }

        public int ModificarClase(int idClase, DateTime fechaClase, TimeSpan horaClase)
        {
            int change = 0;
            using (var con = new isenEntities()) {
                CLASES clase = con.CLASES.Find(idClase);
                if (clase != null) 
                {
                    clase.FECHA = fechaClase;
                    clase.HORA = horaClase;
                    change = con.SaveChanges();
                }
            }
            return change;
        }

        public bool IsAlumnoAsignatura(int idClase, int idUsuario)
        {
            using (var con = new isenEntities())
            {
                ASIGNATURAS asignatura = con.ASIGNATURAS.Find(con.CLASES.Find(idClase).ID_ASIGNATURA);

                if (asignatura != null)
                {
                    MATRICULA matricula = con.MATRICULA.Where(x => asignatura.ID == x.ID_ASIGNATURA && idUsuario == x.ID_ALUMNO).SingleOrDefault();
                    return matricula != null;
                }
            }

            return false;
        }

        public void ModificarAsistencia(int idClase, int idUsuario, bool asiste)
        {
            using (var con = new isenEntities()) 
            {
                REGISTROS registro = con.REGISTROS.Where(x => x.ID_CLASE == idClase && x.ID_ALUMNO == idUsuario).SingleOrDefault();
                if (registro == null)
                {
                    if (asiste)
                    {
                        REGISTROS r = new REGISTROS()
                        {
                            ID_ALUMNO = idUsuario,
                            ID_CLASE = idClase,
                            ASISTE = true,
                            FECHA_REGISTRO = DateTime.Now
                        };
                        con.REGISTROS.Add(r);
                    }
                }
                else 
                {
                    registro.ASISTE = asiste;
                    registro.FECHA_REGISTRO = DateTime.Now;
                    con.SaveChanges();
                }
            }
        }
    }
}