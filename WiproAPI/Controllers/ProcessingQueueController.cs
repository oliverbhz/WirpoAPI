using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WiproAPI.Data;
using WiproAPI.Models;

namespace WiproAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProcessingQueueController : ControllerBase
	{
		[HttpGet]
		[Route("")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProcessingQueue>> GetItemFila([FromServices] DataContext context)
		{
			try
			{
				var queues = await context.Queues.ToListAsync();
				var queuesFiltred = queues.Where(q => q.Ativo == true).OrderByDescending(q => q.Id).FirstOrDefault();

				if (queuesFiltred is null)
					return NotFound();

				queuesFiltred.Ativo = false;
				context.Entry(queuesFiltred).State = EntityState.Modified;

				await context.SaveChangesAsync();

				return queuesFiltred;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		[HttpPost]
		[Route("")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<ProcessingQueue>> AddItemFila([FromServices] DataContext context, [FromBody] ProcessingQueue[] model)
		{
			try
			{
				if (model is null)
					return BadRequest();

				if (ModelState.IsValid)
				{
					foreach (var item in model)
					{
						context.Queues.Add(item);
						await context.SaveChangesAsync();
					}

					return StatusCode(200);
				}
				else
				{
					return BadRequest(ModelState);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}

		}
	}
}
