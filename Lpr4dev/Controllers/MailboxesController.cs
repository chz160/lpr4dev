﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lpr4dev.Data;
using Lpr4dev.DbModel;
using Lpr4dev.Server.Settings;

namespace Lpr4dev.Controllers
{
    /// <summary>
    /// Returns information about the version of lpr4dev
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [UseEtagFilter]
    public class MailboxesController : Controller
    {
        private Lpr4devDbContext dbContext;

        public MailboxesController(Lpr4devDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets list of mailboxes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IList<Mailbox>> GetAll()
        {
            return this.dbContext.Mailboxes.ToList();
        }
    }
}