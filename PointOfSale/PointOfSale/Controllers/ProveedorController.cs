﻿using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class ProveedorController: IController<Proveedor>
    {
        public bool Delete(Proveedor o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    o.IsDeleted = true;
                    db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool Delete(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.Proveedor.FirstOrDefault(x => x.ProveedorId == Id.Trim());
                    if (temp != null)
                    {
                        temp.IsDeleted = true;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Proveedor o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Add(o);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Proveedor> lista)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.AddRange(lista);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public List<Proveedor> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Proveedor.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Proveedor> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Proveedor.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public Proveedor SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Proveedor.FirstOrDefault(x => x.ProveedorId == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Proveedor> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Proveedor.Where(x => x.ProveedorId == Id.Trim()).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Proveedor o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }
    }
}
