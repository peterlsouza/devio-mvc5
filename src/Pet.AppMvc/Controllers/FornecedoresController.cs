using AutoMapper;
using Pet.AppMvc.ViewModels;
using Pet.Business.Core.Notifications;
using Pet.Business.Models.Fornecedores;
using Pet.Business.Models.Fornecedores.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pet.AppMvc.Controllers
{
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository; // pra fazer leitura
        private readonly IFornecedorService _fornecedorService;   //pra fazer persistência, salvar, modificar o banco
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IFornecedorService fornecedorService,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }


        [Route("lista-de-fornecedores")]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos()));
        }

        [Route("dados-do-fornecedor/{id:guid}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(fornecedorViewModel);
        }

        [Route("novo-fornecedor")]
        public ActionResult Create()
        {
            return View();
        }


        [Route("novo-fornecedor")]
        [HttpPost]
        public async Task<ActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(fornecedorViewModel);
            }

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel); //cria uma instancia da entidade fornecedor
            await _fornecedorService.Adicionar(fornecedor);  // e adiciona a entidade no banco..

            if(!OperacaoValida())
            {
                return View(fornecedorViewModel);
            }

            return RedirectToAction("Index");
        }


        [Route("editar-fornecedor/{id:guid}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(fornecedorViewModel);

        }

        [Route("editar-fornecedor/{id:guid}")]
        [HttpPost]
        public async Task<ActionResult> Edit (Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid) 
            {
                return View(fornecedorViewModel);
            }
            ;
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);//mapeando a fornecedorViewModel para a Entidade Fornecedor
            await _fornecedorService.Atualizar(fornecedor);

            //TODO - senão for sucesso?

            return RedirectToAction("Index");
        }


        [Route("excluir-fornecedor/{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(fornecedorViewModel);
        }

        [Route("excluir-fornecedor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed (Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            await _fornecedorService.Remover(id);

            //TODO: se der erro?

            return RedirectToAction("Index");
        }

        [Route("obter-endereco-fornecedor/{id:guid}")]
        public async Task<ActionResult> ObterEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DetalhesEndereco", fornecedor);
        }


        [Route("atualizar-endereco-fornecedor/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> AtualizarEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            return PartialView("_AtualizarEndereco", new FornecedorViewModel { Endereco = fornecedor.Endereco });
        }

        [Route("atualizar-endereco-fornecedor/{id:guid}")]
        [HttpPost]
        public async Task<ActionResult> AtualizarEndereco(FornecedorViewModel fornecedorViewModel) //estamos fornecendo os dados do fornecedor completo! **inclui o endereço..
        {
            ModelState.Remove("Nome"); //como vamos atualizar apenas endereço, não precisa validar estes campos..
            ModelState.Remove("Documento"); //como vamos atualizar apenas endereço, não precisa validar estes campos..

            if (!ModelState.IsValid)
            {
                return PartialView("_AtualizarEndereco", fornecedorViewModel);
            }

            await _fornecedorService.AtualizarEndereco(_mapper.Map<Endereco>(fornecedorViewModel.Endereco));

            //TODO: senão der certo

            var url = Url.Action("ObterEndereco", "Fornecedores", new { id = fornecedorViewModel.Endereco.FornecedorId}); //vai montar a URL aqui.. action ObterEndereco

            return Json(new { success = true, url}); //quem vai chamar vai ser o javascript via ajax..
        }

        //metodos para auxiliar nos demais... 
        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

    }
}