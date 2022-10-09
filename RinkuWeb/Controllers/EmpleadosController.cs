using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RinkuWeb.Models;

namespace RinkuWeb.Controllers
{
    public class EmpleadosController
    {
        public EmpleadosController()
        {
        }
        [HttpPost]
        [Route("Api/SetNewEmpleado")]
        public int SetNewEmpleado([FromBody] Empleado empleado)
        {
            try
            {
                using (RinkuContext db=new RinkuContext())
                {
                    if (empleado.CvEmpleado>0)
                    {
                        var empleadodb = db.Empleados.Where(x => x.CvEmpleado == empleado.CvEmpleado).FirstOrDefault();
                        empleadodb = empleado;
                        db.SaveChanges();
                        return 1;
                         
                    }
                    else
                    {
                        db.Empleados.Add(empleado);
                        db.SaveChanges();
                        return 1;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        [HttpGet]
        [Route("Api/GetAllEmpleados")]
        public IEnumerable<Empleado> GetAllEmpleados()
        {
            try
            {
                using (RinkuContext db=new RinkuContext())
                {
                    List<Empleado> empleados = db.Empleados.ToList();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("Api/GetEmpleado/{cv}")]
        public Empleado GetEmpleado(int cv)
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    Empleado empleado = db.Empleados.Where(x=>x.CvEmpleado==cv).First();
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet]
        [Route("Api/GetRepet/{numeroE}")]
        public int GetRepet(string numeroE)
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    int empleado = db.Empleados.Where(x => x.NumeroEmpleado == numeroE).Count();
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }


        //----------------------------------------------------------
        [HttpPost]
        [Route("Api/SetNewMoviemiento")]
        public int SetNewMoviemiento([FromBody] Movimiento movimiento)
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
              
                        db.Movimientos.Add(movimiento);
                        db.SaveChanges();

                        var nomina = SetCalculate(movimiento);
                        db.Nominas.Add(nomina);
                        db.SaveChanges();

                        return 1;

                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        [HttpGet]
        [Route("Api/GetallMoviemiento")]
        public IEnumerable<Movimiento> GetallMoviemiento()
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    List<Movimiento> movimientos = db.Movimientos.ToList();
                    return movimientos;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("Api/GetMovimiento/{cv}")]
        public Movimiento GetMovimiento(int cv)
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    Movimiento movimiento = db.Movimientos.Where(x => x.CvMovimiento == cv).First();
                    return movimiento;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("Api/SetNewNomina")]
        public int SetNewNomina([FromBody] Nomina nomina)
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    if (nomina.CvNomina > 0)
                    {
                        var nominadb = db.Nominas.Where(x => x.CvNomina == nomina.CvMovimiento).FirstOrDefault();
                        nominadb = nomina;
                        db.SaveChanges();
                        return 1;

                    }
                    else
                    {
                        db.Nominas.Add(nomina);
                        db.SaveChanges();
                        return 1;
                    }


                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        [HttpGet]
        [Route("Api/GetAllNomina")]
        public IEnumerable<Nomina> GetAllNomina()
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    List<Nomina> nominas = db.Nominas.ToList();
                    return nominas;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("Api/GetNomina/{cv}")]
        public Nomina GetNomina(int cv)
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    Nomina nomina = db.Nominas.Where(x => x.CvNomina == cv).First();
                    return nomina;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        [HttpGet]
        [Route("Api/GetTipoEmpleado")]
        public IEnumerable<TipoEmpleado> GetTipoEmpleado()
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    List<TipoEmpleado> tipoEmpleados = db.TipoEmpleados.ToList();
                    return tipoEmpleados;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet]
        [Route("Api/GetAllPeriodos")]
        public IEnumerable<Periodo> GetAllPeriodos()
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    List<Periodo> periodos = db.Periodos.ToList();
                    return periodos;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Nomina SetCalculate(Movimiento movimiento)
        {
            try
            {
                //Calculo de nomina por empleado
                var dias = 6;
                var hora = 8;
                var sueldohora = 30;
                var TotalHoras = (hora * dias * 4)-movimiento.HDesc;
                var SueldoTotal = TotalHoras * sueldohora;
                var bonoentregas = movimiento.NumEntregas * 5;
                var bonopuesto = GetTabuladorBono(movimiento.CvTipoEmpleado) * TotalHoras;
                var sueldobruto = SueldoTotal + bonoentregas  +bonopuesto;
                var reteciones = SetRetencionISR((decimal)sueldobruto);
                var sueldoneto = sueldobruto - reteciones;
                var valesdespensa = (double)sueldoneto * 0.04;

                Nomina nomina = new Nomina()
                {
                    BonoEntregas = bonoentregas,
                    BonoPuesto = bonopuesto,
                    SueldoBruto = sueldobruto,
                    Retenciones = reteciones,
                    SueldoNeto = sueldoneto,
                    ValesDespensa= (decimal?)valesdespensa,
                    CvPeriodo=movimiento.CvPeriodo,
                    CvMovimiento=movimiento.CvMovimiento,
                    CvNomina=0,
                    HorasTrabajadas=TotalHoras


                };
                


                return nomina;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public decimal GetTabuladorBono(int cvtipo)
        {
            try
            {
                using (RinkuContext db=new RinkuContext())
                {
                    var tabulador = db.TipoEmpleados.Where(x => x.CvTipoEmpleado == cvtipo).First().TabuladorHora;
                    return (decimal)tabulador;
                }
                    
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public decimal SetRetencionISR(decimal sueldoBruto)
        {
            try
            {
                if (sueldoBruto<=10000)
                {
                    var retencion = (double)sueldoBruto * 0.09;
                    return (decimal)retencion;
                }
                else
                {
                    var retencion = (double)sueldoBruto * 0.03;
                    return (decimal)retencion;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        [HttpGet]
        [Route("Api/QueryNominas/")]
        public IEnumerable<QueryClass> QueryNominas()
        {
            try
            {
                using (RinkuContext db = new RinkuContext())
                {
                    List<QueryClass> queries = (from emp in db.Empleados
                                                from mov in db.Movimientos
                                                from nom in db.Nominas
                                                from per in db.Periodos
                                                where nom.CvMovimiento == mov.CvMovimiento
                                                && mov.CvEmpleado == emp.CvEmpleado
                                                && nom.CvPeriodo == per.CvPeriodo
              
                                                orderby per.NumMesPeriodo

                                                select new QueryClass
                                                {
                                                    numEmpleado=emp.NumeroEmpleado,
                                                    nombre=emp.Nombre,
                                                    periodo=per.Descripcion,
                                                   
                                                    bonotipoempleado= (decimal)nom.BonoPuesto,
                                                    bonoentregas= (decimal)nom.BonoEntregas,
                                                    horastrabajadas= (decimal)nom.HorasTrabajadas,
                                                    vales= (decimal)nom.ValesDespensa,
                                                    sueldobruto= (decimal)nom.SueldoBruto,
                                                    sueldonet= (decimal)nom.SueldoNeto,
                                                    reteciones= (decimal)nom.Retenciones,
                                                    
                                                    
                                                }
                                              ).ToList();
                    return queries;
                }

               
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
