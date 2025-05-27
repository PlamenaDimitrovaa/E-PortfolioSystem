namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;

    public class ChatEntityConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
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

        private Chat[] GenerateChats()
        {
            ICollection<Chat> chats = new HashSet<Chat>();

            Chat chat;

            chat = new Chat()
            {

            };

            chats.Add(chat);

            return chats.ToArray();
        }
    }
}
