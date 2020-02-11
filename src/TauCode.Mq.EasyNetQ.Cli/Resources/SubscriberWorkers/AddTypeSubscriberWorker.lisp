(defblock :name message-subscribe :is-top t
	(worker
		:worker-name message-subscribe
		:verb "add"
		:description "Adds a subscription to the subscriber."
		:usage-samples (
			"sub add Foo.Messages.MyMessage"))

	(end)
)
