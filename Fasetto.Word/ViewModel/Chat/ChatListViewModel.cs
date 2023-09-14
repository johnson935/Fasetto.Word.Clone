using Fasetto.Word.ViewModel.Base;
using System.Collections.Generic;

namespace Fasetto.Word.ViewModel.Chat
{
    /// <summary>
    /// A view model for the overview chat list
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
