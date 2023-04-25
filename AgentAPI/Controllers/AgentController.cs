using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgentAPI.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public AgentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("agents")]
        public async Task<ActionResult<List<Agent>>> Get()
        {
            return Ok(await _dataContext.Agents.ToArrayAsync());
        }

        [HttpPost("agent")]
        public async Task<ActionResult<List<Agent>>> AddAgent(Agent agent)
        {
            _dataContext.Agents.Add(agent);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Agents.ToListAsync());
        }

        [HttpPut("agent/{name}")]
        public async Task<ActionResult<List<Agent>>> UpdateAgent(string name, Agent agent)
        {
            var agents = await _dataContext.Agents.Where(a => a.Name == name).ToListAsync();
            if (agents == null)
                return BadRequest("Agent Not Found");

            var agentToUpdate = agents.First();

            agentToUpdate.Os = agent.Os;
            agentToUpdate.LastKeepAlive = agent.LastKeepAlive;
            agentToUpdate.DateAdd = agent.DateAdd;
            agentToUpdate.Ip = agent.Ip;
            agentToUpdate.Version = agent.Version;
            agentToUpdate.Status = agent.Status;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Agents.ToListAsync());
        }

        [HttpDelete("agent/{id}")]
        public async Task<ActionResult<List<Agent>>> Delete(int id)
        {
            var agent = await _dataContext.Agents.FindAsync(id);

            if (agent == null)
                return BadRequest("Agent Not Found");

            _dataContext.Agents.Remove(agent);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Agents.ToListAsync());
        }
    }
}
