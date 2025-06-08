namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ChatEntityConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Sender)
                .WithMany()
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Receiver)
                .WithMany()
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(this.GenerateChats());
        }

        private ChatMessage[] GenerateChats()
        {
            ICollection<ChatMessage> chats = new HashSet<ChatMessage>();

            ChatMessage chat;

            chat = new ChatMessage()
            {

            };

            chats.Add(chat);

            return chats.ToArray();
        }
    }
}
